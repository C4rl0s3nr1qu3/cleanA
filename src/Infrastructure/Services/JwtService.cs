using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using CleanA.Application.Common.Interfaces;
using CleanA.Domain.Entities;

namespace CleanA.Infrastructure.Services;
public class JwtService : IJwtService
{
    private readonly string _secretKey;

    public JwtService(string secretKey)
    {
        _secretKey = secretKey;
    }

    public async Task<string> GenerateTokenAsync(Usuarios usuarios)
    {
        // Create a new claims identity for the user.
        var claimsIdentity = new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuarios.Id.ToString()),
            new Claim(ClaimTypes.Name, usuarios.Name),
            new Claim("TenantId", usuarios.IdOrganizaciones)
        });

        // Create a new security token for the user.
        var securityToken = new JwtSecurityToken(
            issuer: "https://example.com",
            audience: "https://example.com",
            claims: claimsIdentity.Claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey)), SecurityAlgorithms.HmacSha256)
        );

        // Serialize the security token to a JWT token string.
        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return token;
    }

    public async Task<Usuarios> ValidateTokenAsync(string token)
    {
        // Validate the JWT token.
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey)),
            ClockSkew = TimeSpan.Zero
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);


        // Get the user's identity from the claims.
        //var claimsIdentity = (ClaimsIdentity)validatedToken.Identity;
        var claimsIdentity = (ClaimsIdentity)securityToken.Identity;

        var userIdentity = new Usuarios
        {
            Id = (claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value),
            Name = claimsIdentity.FindFirst(ClaimTypes.Name).Value,
            IdOrganizaciones = claimsIdentity.FindFirst("TenantId").Value
        };

        return userIdentity;
    }
}
