namespace DSV.WebApi.Models.ProviderServices;

public class CreateProviderService
{
    public int ServiceId { get; set; }
    public decimal PricePerHour { get; set; } 
    public int DurationMinutes { get; set; }
}