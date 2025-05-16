using FluentValidation;
using Sig.SecurityServiceTenant.Domain.ObjectValues;

namespace Sig.SecurityServiceTenant.Domain.Validations;

public class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        RuleFor(x => x.Address)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(150);
    }
}