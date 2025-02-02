using DSV.Persistence.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSV.Persistence.Sql.EntityConfigurations;

internal sealed  class ProviderServiceEntityConfiguration : IEntityTypeConfiguration<ProviderService>
{
    public void Configure(EntityTypeBuilder<ProviderService> builder)
    {
        builder.Property(x => x.PricePerHour).HasPrecision(18, 2).IsRequired();
        builder.Property(x => x.PricePerSession).HasPrecision(18, 2).IsRequired();
        builder.Property(x => x.DurationMinutes).HasPrecision(18, 2).IsRequired();
        
        builder.HasOne(x => x.Provider)
            .WithMany(x => x.ProviderServices)
            .HasForeignKey(x => x.ProviderId);
        
        builder.HasOne(x => x.Service)
            .WithMany()
            .HasForeignKey(x => x.ServiceId);
    }
}