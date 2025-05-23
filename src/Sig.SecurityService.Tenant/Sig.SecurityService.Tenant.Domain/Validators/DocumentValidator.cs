using FluentValidation;
using Sig.SecurityServiceTenant.Domain.Enuns;
using Sig.SecurityServiceTenant.Domain.Validators.Extensions;
using Sig.SecurityServiceTenant.Domain.ValueObjects;

namespace Sig.SecurityServiceTenant.Domain.Validators;

public class DocumentValidator : AbstractValidator<Document>
{
    public DocumentValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty()
            .IsDocument();
    }
}