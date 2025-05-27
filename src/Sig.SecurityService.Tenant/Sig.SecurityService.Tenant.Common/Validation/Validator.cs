using FluentResults;
using FluentValidation;
using Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;

namespace Sig.SecurityService.Tenant.Common.Validation;

public static class Validator
{
    public static async Task<Result> ValidateAsync<T>(T instance)
    {
        Type validatorType = typeof(IValidator<>).MakeGenericType(typeof(T));

        if (Activator.CreateInstance(validatorType) is not IValidator validator)
        {
            throw new InvalidOperationException($"No validator found for: {typeof(T).Name}");
        }

        var result = await validator.ValidateAsync(new ValidationContext<T>(instance));

        if (!result.IsValid)
            return ValidatorFailure.Fail(result.Errors);

        return Result.Ok();
    }
}
