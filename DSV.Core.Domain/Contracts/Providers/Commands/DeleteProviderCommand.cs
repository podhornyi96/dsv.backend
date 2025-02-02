using MediatR;

namespace DSV.Core.Domain.Contracts.Providers.Commands;

public class DeleteProviderCommand : IRequest
{
    public DeleteProviderCommand(int id)
    {
        Id = id;
    }

    public int Id { get; }
}