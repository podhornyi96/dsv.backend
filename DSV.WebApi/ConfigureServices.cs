using DSV.Core.Domain;
using DSV.Persistence.Sql;
using DSV.WebApi.Common;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace DSV.WebApi;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddAutoMapper(typeof(Program));
        
        services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssemblyContaining(typeof(Program));
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatorDiscovery).Assembly));

        return services;
    }
}