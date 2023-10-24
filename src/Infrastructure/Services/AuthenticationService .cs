using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CleanA.Application.Common.Interfaces;
using CleanA.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CleanA.Infrastructure.Services;
public class AuthenticationService : IAuthenticationService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IJwtService _jwtService;

    public AuthenticationService(IUsuarioRepository usuarioRepository, IJwtService jwtService)
    {
        _usuarioRepository = usuarioRepository;
        _jwtService = jwtService;
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        // Validate the user's credentials.
        Usuarios usuarios = await _usuarioRepository.GetUsuariosByName(username);
        if (usuarios == null || !_usuarioRepository.VerifyPassword(password))
        {
            throw new Exception("Invalid username or password.");
        }

        // Generate a JWT token for the user.
        var token = await _jwtService.GenerateTokenAsync(usuarios);

        return token;
    }


    Task<AuthenticateResult> IAuthenticationService.AuthenticateAsync(HttpContext context, string? scheme)
    {
        throw new NotImplementedException();
    }

    Task IAuthenticationService.ChallengeAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
    {
        throw new NotImplementedException();
    }

    Task IAuthenticationService.ForbidAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
    {
        throw new NotImplementedException();
    }

    Task IAuthenticationService.SignInAsync(HttpContext context, string? scheme, ClaimsPrincipal principal, AuthenticationProperties? properties)
    {
        throw new NotImplementedException();
    }

    Task IAuthenticationService.SignOutAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
    {
        throw new NotImplementedException();
    }
}
