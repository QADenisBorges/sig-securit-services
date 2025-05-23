using FluentValidation;
using Sig.SecurityServiceTenant.Domain.Entities;

namespace Sig.SecurityServiceTenant.Domain.Validators;

public class TenantValidator : AbstractValidator<Tenant>
{
    public TenantValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .SetValidator(new EmailValidator());

        RuleFor(x => x.Document)
            .SetValidator(new DocumentValidator());

        RuleFor(x => x.Phone)
            .SetValidator(new PhoneValidator());

        RuleFor(x => x.WhatsappPhone)
            .SetValidator(new PhoneValidator());

        When(x => x.Address != null, () =>
        {
            RuleFor(x => x.Address!)
                .SetValidator(new AddressValidator());
        });

        When(x => x.Plan != null, () =>
        {
            RuleFor(x => x.Plan!)
                .SetValidator(new PlanValidator());
        });
    }
}