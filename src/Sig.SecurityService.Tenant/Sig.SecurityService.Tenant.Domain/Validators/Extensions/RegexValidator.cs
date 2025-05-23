using FluentValidation;
using Sig.SecurityServiceTenant.Domain.Validations.Proprierties;

namespace Sig.SecurityServiceTenant.Domain.Validators.Extensions;

public static class RegexValidator
{
    public static IRuleBuilderOptions<T, string> IsCpf<T>(this IRuleBuilder<T, string> ruleBuilder)
       => ruleBuilder.SetValidator(new CpfPropertyValidator<T>());

    public static IRuleBuilderOptions<T, string> IsCnpj<T>(this IRuleBuilder<T, string> ruleBuilder)
        => ruleBuilder.SetValidator(new CnpjPropertyValidator<T>());

    public static IRuleBuilderOptions<T, string> IsDocument<T>(this IRuleBuilder<T, string> ruleBuilder)
        => ruleBuilder.SetValidator(new DocumentPropertyValidator<T>());

    public static IRuleBuilderOptions<T, string> IsPhone<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Matches(RegexPatterns.Phone)
            .WithMessage("Invalid phone number format.");
    }

    public static IRuleBuilderOptions<T, long> IsPhone<T>(this IRuleBuilder<T, long> ruleBuilder)
    {
        return ruleBuilder
            .Must(number => RegexPatterns.Phone.IsMatch(number.ToString()))
            .WithMessage("Invalid phone number format.");
    }

    public static IRuleBuilderOptions<T, string> IsName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Matches(RegexPatterns.Name)
            .WithMessage("Invalid name format.");
    }

    public static IRuleBuilderOptions<T, string> IsPostalCode<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Matches(RegexPatterns.PostalCode)
            .WithMessage("Invalid postal code format. Expected format: 00000-000");
    }

    public static IRuleBuilderOptions<T, string> IsUfCode<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder
            .Matches(RegexPatterns.UfCode.ToString())
            .WithMessage("Invalid state code. Must be 2 uppercase letters.");
    }
}
