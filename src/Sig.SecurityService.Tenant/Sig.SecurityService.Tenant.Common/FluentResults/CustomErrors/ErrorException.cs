using FluentResults;
using FluentValidation.Results;
using Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors.Errors;
using System.Runtime.Serialization;

namespace Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;

public class ErrorException : Exception
{
    public Result ResultFailed { get; }

    public ErrorException(IError error)
    {
        ResultFailed = Result.Fail(error);
    }

    public ErrorException(List<IError> errors)
    {
        ResultFailed = Result.Fail(errors);
    }

    public ErrorException(ValidationResult tenantValid)
    {
        ResultFailed = new ValidatorError(tenantValid);
    }

    public ErrorException(CustomError error)
    {
        ResultFailed = error;
    }
}
