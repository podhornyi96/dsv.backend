using DSV.Core.Domain.Contracts.Exceptions;
using DSV.Core.Domain.Contracts.Providers.Commands;
using DSV.Core.Domain.Entities.Providers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DSV.Persistence.Sql.Providers.Commands;

internal sealed class UpdateProviderCommandHandler : IRequestHandler<UpdateProviderCommand, Provider>
{
    private readonly DsvDbContext _context;

    public UpdateProviderCommandHandler(DsvDbContext context)
    {
        _context = context;
    }

    public async Task<Provider> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
    {
        var provider = await _context.Providers
            .FirstOrDefaultAsync(x => x.Id == request.Provider.Id, cancellationToken);

        if (provider is null)
        {
            throw new NotFoundException(nameof(Provider), request.Provider.Id);
        }
        
        provider.FirstName = request.Provider.FirstName;
        provider.LastName = request.Provider.LastName;
        provider.Email = request.Provider.Email;
        provider.Description = request.Provider.Description;
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return new Provider(provider.Id, provider.FirstName, 
            provider.LastName, provider.Email, provider.Description);
    }
}