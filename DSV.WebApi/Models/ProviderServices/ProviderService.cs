namespace DSV.WebApi.Models.ProviderServices;

public class ProviderService
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal PricePerHour { get; set; }
    public int DurationMinutes { get; set; }
    public decimal PricePerSession { get; set; }
}