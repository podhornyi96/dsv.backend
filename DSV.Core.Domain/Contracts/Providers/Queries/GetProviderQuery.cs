using DSV.Core.Domain.Entities.Providers;
using MediatR;

namespace DSV.Core.Domain.Contracts.Providers.Queries;

public class GetProviderQuery : IRequest<Provider?>
{
    public GetProviderQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}