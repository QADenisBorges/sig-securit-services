using FluentValidation;
using Sig.SecurityServiceTenant.Domain.ObjectValues;

namespace Sig.SecurityServiceTenant.Domain.Validations;

public class PhoneValidator : AbstractValidator<Phone>
{
    public PhoneValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty()
            .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$")
            .WithMessage("Telefone inválido.")
            .MaximumLength(20);
    }
}
