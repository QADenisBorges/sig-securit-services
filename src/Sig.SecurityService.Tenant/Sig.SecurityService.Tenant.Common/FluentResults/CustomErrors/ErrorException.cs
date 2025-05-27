using FluentResults;

namespace Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;

public class ErrorException : Exception
{
    public readonly Error Error;

    public ErrorException(Error error) => Error = error;
}
