using Ardalis.GuardClauses;

namespace DSV.Core.Domain.Entities.Providers;

public class ProviderService
{
    public ProviderService(int id, int serviceId, string name, decimal pricePerHour, int durationMinutes)
    {
        Guard.Against.Negative(pricePerHour, nameof(pricePerHour));
        Guard.Against.Negative(durationMinutes, nameof(durationMinutes));
        
        Id = id;
        ServiceId = serviceId;
        Name = name;
        
        PricePerHour = pricePerHour;
        DurationMinutes = durationMinutes;
        PricePerSession = pricePerHour / 60 * DurationMinutes;
    }
    
    public int Id { get; }
    public string Name { get; }
    public int ServiceId { get; }
    public decimal PricePerHour { get; }
    public int DurationMinutes { get; }
    public decimal PricePerSession { get; }
}