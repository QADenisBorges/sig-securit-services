using FluentValidation;
using FluentValidation.Validators;

namespace Sig.SecurityServiceTenant.Domain.Validators.Proprierties;

public class CnpjPropertyValidator<T> : PropertyValidator<T, string>
{
    public override string Name => "CnpjPropertyValidator";

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        var cnpj = new string(value.Where(char.IsDigit).ToArray());

        if (cnpj.Length != 14 || cnpj.Distinct().Count() == 1)
            return false;

        int[] mult1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] mult2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

        int sum1 = 0;
        for (int i = 0; i < 12; i++)
            sum1 += (cnpj[i] - '0') * mult1[i];
        var digit1 = sum1 % 11 < 2 ? 0 : 11 - sum1 % 11;

        int sum2 = 0;
        for (int i = 0; i < 13; i++)
            sum2 += (cnpj[i] - '0') * mult2[i];
        var digit2 = sum2 % 11 < 2 ? 0 : 11 - sum2 % 11;

        return cnpj[12] - '0' == digit1 && cnpj[13] - '0' == digit2;
    }

    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must be a valid CNPJ.";
}
