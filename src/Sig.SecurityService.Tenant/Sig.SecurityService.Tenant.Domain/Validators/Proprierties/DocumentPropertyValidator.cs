using FluentValidation;
using FluentValidation.Validators;

namespace Sig.SecurityServiceTenant.Domain.Validators.Proprierties;

public class DocumentPropertyValidator<T> : PropertyValidator<T, string>
{
    public override string Name => "Document";

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        var digits = new string(value.Where(char.IsDigit).ToArray());

        return digits.Length switch
        {
            11 => new CpfPropertyValidator<T>().IsValid(context, digits),
            14 => new CnpjPropertyValidator<T>().IsValid(context, digits),
            _ => false
        };
    }

    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must be a valid CPF or CNPJ.";
}
