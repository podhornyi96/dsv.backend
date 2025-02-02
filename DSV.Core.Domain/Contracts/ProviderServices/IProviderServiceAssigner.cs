using DSV.Core.Domain.Entities.Providers;

namespace DSV.Core.Domain.Contracts.ProviderServices;

public interface IProviderServiceAssigner
{
    Task<ProviderService> AssignAsync(int providerId, int serviceId,
        int durationMinutes, decimal pricePerHour);
}