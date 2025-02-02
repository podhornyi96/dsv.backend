using DSV.WebApi.Models;
using FluentValidation;

namespace DSV.WebApi.Validators;

public class CreateProviderValidator : AbstractValidator<CreateProvider>
{
    public CreateProviderValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}