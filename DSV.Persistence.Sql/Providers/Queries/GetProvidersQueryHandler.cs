using DSV.Core.Domain.Contracts.Providers.Queries;
using DSV.Core.Domain.Entities.Common;
using DSV.Core.Domain.Entities.Providers;
using DSV.Persistence.Sql.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DSV.Persistence.Sql.Providers.Queries;

internal sealed class GetProvidersQueryHandler : IRequestHandler<GetProvidersQuery, ResultSet<Provider>>
{
    private readonly DsvDbContext _context;

    public GetProvidersQueryHandler(DsvDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultSet<Provider>> Handle(GetProvidersQuery request, CancellationToken cancellationToken)
    {
        var providersQuery = _context.Providers
            .WhereIfNotNullOrEmpty(request.FirstName, provider => provider.FirstName.Contains(request.FirstName!));
        
        var totalCount = await providersQuery.CountAsync(cancellationToken);
        var items = await providersQuery
            .Skip(request.Skip)
            .Take(request.Top)
            .Select(provider => new Provider(provider.Id, provider.FirstName, provider.LastName, provider.Email, provider.Description))
            .ToListAsync(cancellationToken);
        
        return new ResultSet<Provider>(items, totalCount);
    }
    
}