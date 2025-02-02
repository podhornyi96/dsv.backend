using MediatR;

namespace DSV.Core.Domain.Contracts.ProviderServices.Commands;

public class DeleteProviderServiceCommand : IRequest
{
    public DeleteProviderServiceCommand(int providerServiceId)
    {
        ProviderServiceId = providerServiceId;
    }

    public int ProviderServiceId { get; }
}