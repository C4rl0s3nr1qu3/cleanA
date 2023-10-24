using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanA.Domain.Entities;

namespace CleanA.Application.Common.Interfaces;
public interface IUsuarioRepository
{
    public Task<Usuarios> GetUsuariosByName(string id);

    public bool VerifyPassword(string password);
}
