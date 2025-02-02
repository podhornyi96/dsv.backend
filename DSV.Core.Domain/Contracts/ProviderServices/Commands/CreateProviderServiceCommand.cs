using DSV.Core.Domain.Entities.Providers;
using MediatR;

namespace DSV.Core.Domain.Contracts.ProviderServices.Commands;

public class CreateProviderServiceCommand : IRequest<ProviderService>
{
    public CreateProviderServiceCommand(decimal pricePerHour, int durationMinutes, int providerId, 
        int serviceId, string name)
    {
        PricePerHour = pricePerHour;
        DurationMinutes = durationMinutes;
        ProviderId = providerId;
        ServiceId = serviceId;
        Name = name;
    }

    public decimal PricePerHour { get; }
    public int DurationMinutes { get;  }
    public int ProviderId { get; }
    public int ServiceId { get; }
    public string Name { get; }
}