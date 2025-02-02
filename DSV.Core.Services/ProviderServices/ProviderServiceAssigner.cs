using DSV.Core.Domain.Contracts.Exceptions;
using DSV.Core.Domain.Contracts.ProviderServices;
using DSV.Core.Domain.Contracts.ProviderServices.Commands;
using DSV.Core.Domain.Contracts.ProviderServices.Queries;
using DSV.Core.Domain.Contracts.Services;
using DSV.Core.Domain.Entities.Providers;
using DSV.Core.Domain.Entities.Services;
using MediatR;

namespace DSV.Core.Services.ProviderServices;

public class ProviderServiceAssigner : IProviderServiceAssigner
{
    private readonly IMediator _mediator;

    public ProviderServiceAssigner(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ProviderService> AssignAsync(int providerId, int serviceId, 
        int durationMinutes, decimal pricePerHour)
    {
        var service = await _mediator.Send(new GetServiceQuery(serviceId));

        if (service is null)
        {
            throw new NotFoundException(nameof(Service), serviceId);
        }
        
        var providerServicesQuery = new GetProviderServicesQuery(providerId, 0, 1, serviceId);
        var providerServices = await _mediator.Send(providerServicesQuery);

        if (providerServices.Items.Any())
        {
            throw new BusinessException("The provider service has already been assigned.");
        }
        
        var createProviderServiceCommand = new CreateProviderServiceCommand(pricePerHour, durationMinutes, providerId, serviceId, service.Name);
        var providerService = await _mediator.Send(createProviderServiceCommand);
        
        return providerService;
    }
}