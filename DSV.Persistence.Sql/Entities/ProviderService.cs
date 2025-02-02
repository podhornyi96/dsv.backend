namespace DSV.Persistence.Sql.Entities;

internal class ProviderService
{
    public int Id { get; set; }
    public decimal PricePerHour { get; set; }
    public int DurationMinutes { get; set; }
    public decimal PricePerSession { get; set; }
    
    public int ProviderId { get; set; }
    public Provider Provider { get; set; } = default!;
    public int ServiceId { get; set; }
    public Service Service { get; set; } = default!;
}