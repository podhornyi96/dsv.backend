using DSV.Core.Domain;
using DSV.Persistence.Sql;

namespace DSV.WebApi;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatorDiscovery).Assembly));

        return services;
    }
}