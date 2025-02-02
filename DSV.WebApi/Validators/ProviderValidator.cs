using DSV.WebApi.Models;
using FluentValidation;

namespace DSV.WebApi.Validators;

public class ProviderValidator : AbstractValidator<Provider>
{
    public ProviderValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}