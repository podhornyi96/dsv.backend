using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DSV.Persistence.Sql;

public static class ConfigureServices
{

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DSV");
        
        services.AddDbContext<DsvDbContext>(options => options.UseSqlite(connectionString));
        
        return services;
    }
    
}