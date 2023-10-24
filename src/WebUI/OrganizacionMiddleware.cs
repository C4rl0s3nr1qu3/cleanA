using CleanA.Application.Common.Interfaces;

public class OrganizacionMiddleware : IMiddleware
{
    private readonly IOrganizacionRepository _organizacionRepository;

    async Task IMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Get the tenant identifier from the URL path.
        var tenantId = context.Request.Path.Value.Split('/')[1];

        //if ((tenantId.Equals("_configuration")) || (tenantId.Equals("Identity")))
        //    await next(context);
    

        // Get the tenant information from the tenant service.
        var tenant = await _organizacionRepository.GetOrganizacionById(tenantId);

        // Set the tenant on the context.
        context.Items["Tenant"] = tenant.SlugTenat;
        

        // Call the next middleware in the pipeline.
        await next(context);
    }
}
