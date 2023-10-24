using CleanA.Domain.Entities;

namespace CleanA.Application.Common.Interfaces;
public interface IOrganizacionRepository
{
    public Task<Organizaciones> GetOrganizacionById(String id);
}
