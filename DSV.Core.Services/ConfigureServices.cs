using DSV.Core.Domain.Contracts.ProviderServices;
using DSV.Core.Services.ProviderServices;
using Microsoft.Extensions.DependencyInjection;

namespace DSV.Core.Services;

public static class ConfigureServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IProviderServiceAssigner, ProviderServiceAssigner>();
        
        return services;
    }
}