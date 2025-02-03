using DSV.Core.Domain;
using DSV.Persistence.Sql;
using DSV.WebApi.Common;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

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
        
        //NOTE: for demo purposes enabled all CORS
        services.AddCors(options =>
        {
            options.AddPolicy(name: "CorsPolicy",
                builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
        });
        
        return services;
    }
    
}