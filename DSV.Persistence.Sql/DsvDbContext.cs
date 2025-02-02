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

    public DsvDbContext()
    {
        
    }
    
    public DbSet<Provider> Providers => Set<Provider>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
}