using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanA.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CleanA.Infrastructure;
public class TenantMiddleware : IMiddleware
{
    private readonly IOrganizacionRepository _organizacionRepository;

    public TenantMiddleware(IOrganizacionRepository organizacionRepository)
    {
        _organizacionRepository = organizacionRepository;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Get the tenant identifier from the URL path.
        var tenantId = context.Request.Path.Value.Split('/')[1];

        // Get the tenant information from the tenant service.
        var tenant = await _organizacionRepository.GetOrganizacionById(tenantId);

        // Set the tenant on the context.
        context.Items["Tenant"] = tenant;

        // Call the next middleware in the pipeline.
        await next(context);
    }
}
