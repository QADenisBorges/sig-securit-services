using FluentValidation.Results;

namespace Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors.Errors;

public class ValidatorError : CustomError
{
    public readonly IReadOnlyCollection<string> Errors;


    public ValidatorError(ValidationResult validationResult)
        : base("")
    {
       Errors = validationResult.Errors
            .Select(FormatValidationFailure)
            .ToList();
    }

    private static string FormatValidationFailure(ValidationFailure failure)
        => $"{failure.PropertyName}: {failure.ErrorMessage}";
}

