using FluentResults;
using FluentValidation.Results;

namespace Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;

public class FailureRule : Error
{
    
    public string Code { get; set; }
    public List<string> Errors { get; set; } = [];

    public FailureRule(string code, string message, List<string> errors) 
        : base(message) => Code = code;

    public FailureRule WithError(string error)
    {
        Errors.Add(error);
        return this;
    }

    public ErrorResponse ToResponse()
        => new(Code, Message, Errors );

    public FailureRule WithError(string streetNotFoundCode, string messageError)
    {
        Code = streetNotFoundCode;
        Errors.Add(messageError);

        return this;
    }
}
