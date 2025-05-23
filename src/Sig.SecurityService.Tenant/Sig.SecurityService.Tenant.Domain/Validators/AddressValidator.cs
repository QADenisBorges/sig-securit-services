using FluentValidation;
using Sig.SecurityServiceTenant.Domain.Entities;
using Sig.SecurityServiceTenant.Domain.Validations.Regex;
using Sig.SecurityServiceTenant.Domain.Validators.Extensions;
using Sig.SecurityServiceTenant.Domain.ValueObjects;

namespace Sig.SecurityServiceTenant.Domain.Validators;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(x => x.Street)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Street is required and must be at most 100 characters.");

        RuleFor(x => x.Number)
            .NotEmpty()
            .MaximumLength(20)
            .WithMessage("Number is required and must be at most 20 characters.");

        RuleFor(x => x.Complement)
            .MaximumLength(50)
            .WithMessage("Complement must be at most 50 characters.");

        RuleFor(x => x.District)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("District is required and must be at most 50 characters.");

        RuleFor(x => x.City)
            .NotEmpty()
            .MaximumLength(80)
            .WithMessage("City is required and must be at most 80 characters.");

        RuleFor(x => x.State)
            .NotEmpty()
            .Length(2)
            .Matches(@"^[A-Z]{2}$")
            .WithMessage("State must be the 2-letter uppercase UF code.");

        RuleFor(x => x.PostalCode)
            .NotEmpty()
            .Matches(RegexPatterns.PostalCode)
            .WithMessage("Invalid postal code. Format should be 00000-000.");
    }
}
