using DSV.Core.Domain.Entities.Common;
using DSV.Core.Domain.Entities.Providers;
using MediatR;

namespace DSV.Core.Domain.Contracts.Providers.Queries;

public class GetProvidersQuery : IRequest<ResultSet<Provider>>
{
    public GetProvidersQuery(int skip, int top, string? firstName)
    {
        Skip = skip;
        Top = top;
        FirstName = firstName;
    }

    public int Skip { get; }
    public int Top { get; }
    public string? FirstName { get; }
}