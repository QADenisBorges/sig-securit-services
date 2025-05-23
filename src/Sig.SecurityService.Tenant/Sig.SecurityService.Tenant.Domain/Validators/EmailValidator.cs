using FluentValidation;
using Sig.SecurityServiceTenant.Domain.ValueObjects;

namespace Sig.SecurityServiceTenant.Domain.Validators;

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