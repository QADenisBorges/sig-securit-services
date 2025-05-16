using FluentValidation;
using Sig.SecurityServiceTenant.Domain.ObjectValues;

namespace Sig.SecurityServiceTenant.Domain.Validations;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(x => x.Street)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Number)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Complement)
            .MaximumLength(50);

        RuleFor(x => x.District)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.City)
            .NotEmpty()
            .MaximumLength(80);

        RuleFor(x => x.State)
            .NotEmpty()
            .Length(2);

        RuleFor(x => x.PostalCode)
            .NotEmpty()
            .Matches(@"^\d{5}-\d{3}$")
            .WithMessage("CEP inválido.");
    }
}
