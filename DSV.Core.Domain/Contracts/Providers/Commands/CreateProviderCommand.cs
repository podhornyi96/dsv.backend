using DSV.Core.Domain.Entities.Providers;
using MediatR;

namespace DSV.Core.Domain.Contracts.Providers.Commands;

public class CreateProviderCommand : IRequest<Provider>
{
    public CreateProviderCommand(string firstName, string lastName, string email, string? description)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Description = description;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string? Description { get; }
}