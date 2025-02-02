using DSV.Core.Domain.Entities.Services;
using MediatR;

namespace DSV.Core.Domain.Contracts.Services;

public class GetServiceQuery : IRequest<Service?>
{
    public GetServiceQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}