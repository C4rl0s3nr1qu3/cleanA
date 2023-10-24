using CleanA.Application.Common.Interfaces;
using CleanA.Domain.Entities;
using Dapper;
using System.Data;

namespace CleanA.Infrastructure.Services;

public class OrganizacionRepository : IOrganizacionRepository
{
    private Organizaciones _organizaciones;
    private readonly IDbConnection _connection;

    //public OrganizacionRepository(Organizaciones organizaciones, IDbConnection connection)
    //{
    //    _organizaciones = organizaciones;
    //    _connection = connection;
    //}

    public async Task<Organizaciones> GetOrganizacionById(String id)
    {
        var sql = @"SELECT * FROM Organizacion WHERE Id = @Id ";
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);
        //parameters.Add("@TenantId", _organizaciones.SlugTenat);

        _organizaciones = await _connection.QueryFirstOrDefaultAsync<Organizaciones>(sql, parameters);
        //if(_organizaciones == null)
        //{
        //    _organizaciones = new Organizaciones();
        //    _organizaciones.SlugTenat = id;
        //}

        return _organizaciones;
    }
}
