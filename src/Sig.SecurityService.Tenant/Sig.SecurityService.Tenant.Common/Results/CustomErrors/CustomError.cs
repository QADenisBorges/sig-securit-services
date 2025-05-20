using FluentResults;
using System.Text.Json;

namespace Sig.SecurityService.Tenant.Common.Results.CustomErrors;

public abstract class CustomError : Error
{
    public readonly string Code;
    public readonly string Message;
    public readonly string Source;

    protected CustomError(Type sourceType, string code, string message)
        : base(message)
    {
        Code = code;
        Message = message;
        Source = sourceType.Name;

        Metadata[nameof(Code)] = code;
        Metadata[nameof(Message)] = message;
        Metadata[nameof(Source)] = Source;
    }

    public virtual object ToObjectResponse()
    {
        return new
        {
            Type = Source,
            Code,
            Message
        };
    }

    public override string ToString() =>
        JsonSerializer.Serialize(ToObjectResponse(), new JsonSerializerOptions { WriteIndented = true });
}

