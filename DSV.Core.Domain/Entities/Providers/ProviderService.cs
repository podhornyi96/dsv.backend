namespace DSV.Core.Domain.Entities.Providers;

public class ProviderService
{
    public ProviderService(int serviceId, string name, decimal pricePerHour, int durationMinutes)
    {
        ServiceId = serviceId;
        Name = name;
        
        PricePerHour = pricePerHour;
        DurationMinutes = durationMinutes;
        PricePerSession = pricePerHour / 60 * DurationMinutes;
    }
    
    public string Name { get; }
    public int ServiceId { get; }
    public decimal PricePerHour { get; }
    public int DurationMinutes { get; }
    public decimal PricePerSession { get; }
}