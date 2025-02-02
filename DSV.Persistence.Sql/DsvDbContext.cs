using System.Reflection;
using DSV.Persistence.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace DSV.Persistence.Sql;

public class DsvDbContext : DbContext
{
    public DsvDbContext(
        DbContextOptions<DsvDbContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Provider> Providers => Set<Provider>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<ProviderService> ProviderServices => Set<ProviderService>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
}