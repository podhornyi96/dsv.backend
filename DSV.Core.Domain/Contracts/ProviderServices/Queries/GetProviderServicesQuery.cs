using DSV.Core.Domain.Entities.Common;
using DSV.Core.Domain.Entities.Providers;
using MediatR;

namespace DSV.Core.Domain.Contracts.ProviderServices.Queries;

public class GetProviderServicesQuery : IRequest<ResultSet<ProviderService>>
{
    public GetProviderServicesQuery(int providerId, int skip, int top, int? serviceId = null)
    {
        ProviderId = providerId;
        Skip = skip;
        Top = top;
        ServiceId = serviceId;
    }

    public int Skip { get; }
    public int Top { get; }
    public int ProviderId { get; }
    public int? ServiceId { get; }
}