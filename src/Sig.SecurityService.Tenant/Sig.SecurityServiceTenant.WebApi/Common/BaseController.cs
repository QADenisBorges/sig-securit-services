using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;

namespace Sig.SecurityServiceTenant.WebApi.Common;

public abstract class BaseController : ControllerBase
{
    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
            return HandleSuccess(result);

        return HandleFailure(result.Errors);
    }

    protected IActionResult HandleResult(Result result)
    {
        return result.IsSuccess
            ? NoContent()
            : HandleFailure(result.Errors);
    }

    private IActionResult HandleSuccess<T>(Result<T> result)
    {
        return result.ValueOrDefault is not null
            ? Ok(result.Value)
            : NoContent();
    }

    protected IActionResult HandleFailure(IEnumerable<IError> errors)
    {
        var failure = errors.OfType<FailureRule>().FirstOrDefault();

        if (failure is null)
            return StatusCode(StatusCodes.Status500InternalServerError, errors);

        return HandleFailure(failure);
    }

    protected IActionResult HandleFailure(Error error)
    {
        var response = (error as FailureRule)?.ToResponse();
        if(response is null)
            throw new ErrorException(error);

        return error is ValidatorFailure
            ? BadRequest(response)
            : StatusCode(StatusCodes.Status500InternalServerError, response);
    }

}
