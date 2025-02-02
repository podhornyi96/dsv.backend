using DSV.Core.Domain.Contracts.Providers.Commands;
using DSV.Core.Domain.Entities.Providers;
using MediatR;

namespace DSV.Persistence.Sql.Providers.Commands;

internal sealed class CreateProviderCommandHandler : IRequestHandler<CreateProviderCommand, Provider>
{
    private readonly DsvDbContext _context;

    public CreateProviderCommandHandler(DsvDbContext context)
    {
        _context = context;
    }
    
    public async Task<Provider> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
    {
        var provider = new Entities.Provider
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Description = request.Description,
        };
        
        await _context.Providers.AddAsync(provider, cancellationToken);
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return new Provider(provider.Id, provider.FirstName, provider.LastName, provider.Email, provider.Description);
    }
    
}