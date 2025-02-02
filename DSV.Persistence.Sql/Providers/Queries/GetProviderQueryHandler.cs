using DSV.Core.Domain.Contracts.Providers;
using DSV.Core.Domain.Contracts.Providers.Queries;
using MediatR;
using Provider = DSV.Core.Domain.Entities.Providers.Provider;

namespace DSV.Persistence.Sql.Providers.Queries;

internal sealed class GetProviderQueryHandler : IRequestHandler<GetProviderQuery, Provider?>
{
    private readonly DsvDbContext _context;

    public GetProviderQueryHandler(DsvDbContext context)
    {
        _context = context;
    }

    public async Task<Provider?> Handle(GetProviderQuery request, CancellationToken cancellationToken)
    {
        var provider = await _context.Providers.FindAsync([request.Id], cancellationToken: cancellationToken);
        
        return provider is null ? null : new Provider(provider.Id, provider.FirstName, 
            provider.LastName, provider.Email, provider.Description);
    }
}