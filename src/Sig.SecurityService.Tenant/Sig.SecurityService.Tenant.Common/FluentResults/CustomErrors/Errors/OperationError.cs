using FluentResults;
using FluentValidation.Results;
using System.Text.Json;

namespace Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors.Errors;

public class OperationError : CustomError
{
    public Result ResultFailed { get; }

    public OperationError(Result resultFailed) : base("")
    {
        ResultFailed = resultFailed;
    }

    public OperationError(IError error)
        : base("")
    {
        ResultFailed = Result.Fail(error);
    }

    public OperationError(List<IError> errors):base("")
    {
        ResultFailed = Result.Fail(errors);
    }

    public OperationError(ValidationResult tenantValid) : base("")
    {
        ResultFailed = new ValidatorError(tenantValid);
    }

    public OperationError(Exception ex) : base("")
    {
        ResultFailed = new ExceptionalError(ex);
    }
}

