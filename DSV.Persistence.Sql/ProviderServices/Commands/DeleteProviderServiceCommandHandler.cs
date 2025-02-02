using DSV.Core.Domain.Contracts.ProviderServices.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DSV.Persistence.Sql.ProviderServices.Commands;

internal sealed class DeleteProviderServiceCommandHandler : IRequestHandler<DeleteProviderServiceCommand>
{
    private readonly DsvDbContext _context;

    public DeleteProviderServiceCommandHandler(DsvDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(DeleteProviderServiceCommand request, CancellationToken cancellationToken)
    {
        var providerService = await _context.ProviderServices
            .FirstOrDefaultAsync(ps => ps.Id == request.ProviderServiceId, cancellationToken);

        if (providerService is null)
        {
            return;
        }
        
        _context.ProviderServices.Remove(providerService);

        await _context.SaveChangesAsync(cancellationToken);
    }
    
}