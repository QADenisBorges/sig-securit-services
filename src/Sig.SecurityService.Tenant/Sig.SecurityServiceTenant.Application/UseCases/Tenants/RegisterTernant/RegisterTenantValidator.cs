using FluentValidation;
using Sig.SecurityServiceTenant.Domain.UseCases.Tenants.CreateTenant;
using Sig.SecurityServiceTenant.Domain.Validations;
using Sig.SecurityServiceTenant.Domain.Validations.Extensions;
using Sig.SecurityServiceTenant.Domain.Validations.Proprierties;

namespace Sig.SecurityServiceTenant.Application.UseCases.Tenants.RegisterTernant;

public class RegisterTenantValidator : AbstractValidator<CreateTenantCommand>
{
    public RegisterTenantValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.Document)
            .NotEmpty().WithMessage("Document is required.")
            .IsDocument();

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be valid.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Is;

        When(x => !string.IsNullOrWhiteSpace(x.WhatsappPhone), () =>
        {
            RuleFor(x => x.WhatsappPhone)
                .Matches(@"^\d{10,11}$").WithMessage("WhatsApp number must contain 10 or 11 digits.");
        });

        RuleFor(x => x.Street).NotEmpty();
        RuleFor(x => x.Number).NotEmpty();
        RuleFor(x => x.Complement).NotEmpty();
        RuleFor(x => x.District).NotEmpty();
        RuleFor(x => x.City).NotEmpty();
        RuleFor(x => x.State).NotEmpty();
        RuleFor(x => x.PostalCode).NotEmpty();
    }
}