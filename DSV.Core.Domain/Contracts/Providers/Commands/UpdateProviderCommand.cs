using DSV.Core.Domain.Entities.Providers;
using MediatR;

namespace DSV.Core.Domain.Contracts.Providers.Commands;

public class UpdateProviderCommand : IRequest<Provider>
{
    public UpdateProviderCommand(Provider provider)
    {
        Provider = provider;
    }

    public Provider Provider { get; }
}