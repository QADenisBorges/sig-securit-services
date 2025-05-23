using FluentValidation;
using FluentValidation.Validators;

namespace Sig.SecurityServiceTenant.Domain.Validators.Proprierties;

public class CpfPropertyValidator<T> : PropertyValidator<T, string>
{
    public override string Name => "Cpf";

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        var cpf = new string(value.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
            return false;

        int sum1 = 0;
        for (int i = 0; i < 9; i++)
            sum1 += (cpf[i] - '0') * (10 - i);
        var digit1 = sum1 % 11 < 2 ? 0 : 11 - sum1 % 11;

        int sum2 = 0;
        for (int i = 0; i < 10; i++)
            sum2 += (cpf[i] - '0') * (11 - i);
        var digit2 = sum2 % 11 < 2 ? 0 : 11 - sum2 % 11;

        return cpf[9] - '0' == digit1 && cpf[10] - '0' == digit2;
    }

    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must be a valid CPF.";
}
