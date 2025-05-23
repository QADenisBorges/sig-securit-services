using FluentResults;

namespace Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors.Errors;

public abstract class CustomError : Error
{
    public CustomError(string message)
        : base(message)
    {
    }
}

