using DSV.Persistence.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSV.Persistence.Sql.EntityConfigurations;

internal sealed  class ServiceEntityConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(ct => ct.Id);
        
        builder.Property(ct => ct.Id)
            .ValueGeneratedNever()
            .IsRequired();
        
        builder.HasData(new List<Service>()
        {
            new Service { Id = 10, Name = "Yoga"},
            new Service { Id = 11, Name = "Boxing"},
            new Service { Id = 12, Name = "Stretching"},
        });
        
        builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
    }
}