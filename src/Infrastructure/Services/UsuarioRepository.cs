using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanA.Application.Common.Interfaces;
using CleanA.Domain.Entities;
using Dapper;

namespace CleanA.Infrastructure.Services;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly IDbConnection _connection;
    private string passwordRepository;

    public UsuarioRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<Usuarios> GetUsuariosByName(string name)
    {
        var sql = @"SELECT * FROM Users WHERE Name = @Name ";
        var parameters = new DynamicParameters();
        parameters.Add("@Name", name);
        var usuarios = await _connection.QueryFirstOrDefaultAsync<Usuarios>(sql, parameters);
        passwordRepository = usuarios.Password;
        return usuarios;
    }

    public bool VerifyPassword(string password)
    {
        if(this.passwordRepository.Equals(password))
            return true;
        return false;
    }

 }
