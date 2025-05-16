using FluentValidation;
using Sig.SecurityServiceTenant.Domain.Entities;

namespace Sig.SecurityServiceTenant.Domain.Validations;

public class PlanValidator : AbstractValidator<Plan>
{
    public PlanValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.MonthlyPrice)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.MaxUsers)
            .GreaterThan(0);
    }
}