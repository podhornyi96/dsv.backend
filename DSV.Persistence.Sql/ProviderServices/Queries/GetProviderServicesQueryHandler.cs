using DSV.Core.Domain.Contracts.ProviderServices.Queries;
using DSV.Core.Domain.Entities.Common;
using DSV.Core.Domain.Entities.Providers;
using DSV.Persistence.Sql.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DSV.Persistence.Sql.ProviderServices.Queries;

internal sealed class GetProviderServicesQueryHandler : IRequestHandler<GetProviderServicesQuery, ResultSet<ProviderService>>
{
    private readonly DsvDbContext _context;

    public GetProviderServicesQueryHandler(DsvDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultSet<ProviderService>> Handle(GetProviderServicesQuery request, CancellationToken cancellationToken)
    {
        var providerServicesQuery = _context.ProviderServices
            .Where(providerService => providerService.ProviderId == request.ProviderId)
            .WhereIf(request.ServiceId is not null, providerService => providerService.ServiceId == request.ServiceId);
        
        var totalCount = await providerServicesQuery.CountAsync(cancellationToken);
        var items = await providerServicesQuery
            .Skip(request.Skip)
            .Take(request.Top)
            .Select(providerService => new ProviderService(
                    providerService.ServiceId,
                    providerService.Service.Name,
                    providerService.PricePerHour,
                    providerService.DurationMinutes
                )
            )
            .ToListAsync(cancellationToken);
        
        return new ResultSet<ProviderService>(items, totalCount);
    }
    
}