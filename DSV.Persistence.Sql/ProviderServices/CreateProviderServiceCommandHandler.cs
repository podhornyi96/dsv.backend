using DSV.Core.Domain.Contracts.ProviderServices.Commands;
using DSV.Core.Domain.Entities.Providers;
using MediatR;

namespace DSV.Persistence.Sql.ProviderServices;

internal sealed class CreateProviderServiceCommandHandler : IRequestHandler<CreateProviderServiceCommand, ProviderService>
{
    private readonly DsvDbContext _context;

    public CreateProviderServiceCommandHandler(DsvDbContext context)
    {
        _context = context;
    }
    
    public async Task<ProviderService> Handle(CreateProviderServiceCommand request, CancellationToken cancellationToken)
    {
        var providerService = new DSV.Persistence.Sql.Entities.ProviderService
        {
            PricePerHour = request.PricePerHour,
            DurationMinutes = request.DurationMinutes,
            ProviderId = request.ProviderId,
            ServiceId = request.ServiceId
        };
        
        await _context.ProviderServices.AddAsync(providerService, cancellationToken);
        
        return new ProviderService(providerService.ServiceId, request.Name, providerService.PricePerHour, 
            providerService.DurationMinutes);
    }
    
}