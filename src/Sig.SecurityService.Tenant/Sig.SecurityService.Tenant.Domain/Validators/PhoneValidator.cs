using FluentValidation;
using Sig.SecurityServiceTenant.Domain.Validators.Extensions;
using Sig.SecurityServiceTenant.Domain.ValueObjects;

namespace Sig.SecurityServiceTenant.Domain.Validators;

public class PhoneValidator : AbstractValidator<Phone>
{
    public PhoneValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty()
            .LessThanOrEqualTo(999999999) 
            .IsPhone();
    }
}
