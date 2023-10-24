using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanA.Domain.Entities;

namespace CleanA.Application.Common.Interfaces;
public interface IJwtService
{
    public Task<string> GenerateTokenAsync(Usuarios usuarios);

    public Task<Usuarios> ValidateTokenAsync(string token);
}
