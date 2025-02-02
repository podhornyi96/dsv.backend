using DSV.Core.Domain.Contracts.Services;
using DSV.Core.Domain.Entities.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DSV.Persistence.Sql.Services.Queries;

internal sealed class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, Service?>
{
    private readonly DsvDbContext _context;

    public GetServiceQueryHandler(DsvDbContext context)
    {
        _context = context;
    }
    
    public async Task<Service?> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
        var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        
        return service is null ? null : new Service(service.Id, service.Name);
    }
}