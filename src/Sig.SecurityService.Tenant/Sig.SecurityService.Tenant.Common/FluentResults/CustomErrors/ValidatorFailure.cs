
using FluentValidation.Results;

namespace Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;

public class ValidatorFailure(string code, string message, List<string> errors) : FailureRule(code, message, errors)
{

    public const string DefaultCode = "VALIDATION_ERROR";
    public const string DefaultMessage = "Validation error occurred";

    public static ValidatorFailure Fail(string code)
      => new(code, DefaultMessage, []);

    public static ValidatorFailure Fail(List<ValidationFailure> errors)
           => new(DefaultCode, DefaultMessage, [.. errors.Select(e => e.ErrorMessage)]);
}
