using FluentValidation;
using Sig.SecurityServiceTenant.Domain.Enuns;
using Sig.SecurityServiceTenant.Domain.ObjectValues;

namespace Sig.SecurityServiceTenant.Domain.Validations;

public class DocumentValidator : AbstractValidator<Document>
{
    public DocumentValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty()
            .MaximumLength(18);

        RuleFor(x => x.Type)
            .IsInEnum();

        When(x => x.Type == DocumentType.CPF, () =>
        {
            RuleFor(x => x.Number)
                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
                .WithMessage("CPF inválido.");
        });

        When(x => x.Type == DocumentType.CNPJ, () =>
        {
            RuleFor(x => x.Number)
                .Matches(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$")
                .WithMessage("CNPJ inválido.");
        });
    }
}