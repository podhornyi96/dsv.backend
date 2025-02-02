using DSV.Core.Domain.Contracts.Providers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DSV.Persistence.Sql.Providers.Commands;

internal sealed class DeleteProviderCommandHandler : IRequestHandler<DeleteProviderCommand>
{
    private readonly DsvDbContext _context;

    public DeleteProviderCommandHandler(DsvDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
    {
        var provider = await _context.Providers.FirstOrDefaultAsync(prov => prov.Id == request.Id, cancellationToken);

        if (provider is null)
        {
            return;
        }
        
        _context.Providers.Remove(provider);

        await _context.SaveChangesAsync(cancellationToken);
    }
    
}