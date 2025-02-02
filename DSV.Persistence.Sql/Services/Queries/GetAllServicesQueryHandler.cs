using DSV.Core.Domain.Contracts.Services;
using DSV.Core.Domain.Entities.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DSV.Persistence.Sql.Services.Queries;

internal sealed class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, IReadOnlyList<Service>>
{
    private readonly DsvDbContext _context;

    public GetAllServicesQueryHandler(DsvDbContext context)
    {
        _context = context;
    }
    
    public async Task<IReadOnlyList<Service>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        var services = await _context.Services.ToListAsync(cancellationToken);
        
        return services.Select(service => new Service(service.Id, service.Name)).ToList();
    }
    
}