using FluentValidation;
using Sig.SecurityServiceTenant.Domain.Validators.Proprierties;

namespace Sig.SecurityServiceTenant.Domain.Validators.Extensions;

public static class RegexValidator
{
    public static IRuleBuilderOptions<T, string> IsCpf<T>(this IRuleBuilder<T, string> ruleBuilder)
       => ruleBuilder.SetValidator(new CpfPropertyValidator<T>());

    public static IRuleBuilderOptions<T, string> IsCnpj<T>(this IRuleBuilder<T, string> ruleBuilder)
        => ruleBuilder.SetValidator(new CnpjPropertyValidator<T>());

    public static IRuleBuilderOptions<T, string> IsDocument<T>(this IRuleBuilder<T, string> ruleBuilder)
        => ruleBuilder.SetValidator(new DocumentPropertyValidator<T>());

    public static IRuleBuilderOptions<T, long> IsPhone<T>(this IRuleBuilder<T, long> ruleBuilder)
        => ruleBuilder
            .Must(number => RegexPatterns.Phone.IsMatch(number.ToString()))
            .WithMessage("Invalid phone number format.");

    public static IRuleBuilderOptions<T, string> IsName<T>(this IRuleBuilder<T, string> ruleBuilder)
        => ruleBuilder
            .Matches(RegexPatterns.Name)
            .WithMessage("Invalid name format.");
}
