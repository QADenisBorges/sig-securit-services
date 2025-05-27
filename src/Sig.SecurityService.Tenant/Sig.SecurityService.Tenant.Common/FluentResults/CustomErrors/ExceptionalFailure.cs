using FluentResults;

namespace Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;

public class ExceptionalFailure : FailureRule
{
    public readonly IError Error;
    public const string DefaultCode = "EXCEPTION_ERROR";
    public const string DefaultMessage = "An error occurred";

    public ExceptionalFailure(string code, string message, List<string> errors)
    : base(code, message, errors)
    {
        Error = this;
    }

    public static ExceptionalFailure Fail(string message)
        => new(DefaultCode, message, []);

    public static ExceptionalFailure Fail(Exception exception)
        => Create(exception.Message, exception);

    public static ExceptionalFailure Fail(string message, Exception exception)
        => Create(message, exception);

    private static ExceptionalFailure Create(string message, Exception exception)
    {
        var errors = exception.InnerException is not null
            ? exception.InnerException.Message
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
            : new List<string> { exception.Message };

        var failure = new ExceptionalFailure(DefaultCode, message, errors);

        return failure;
    }
}


