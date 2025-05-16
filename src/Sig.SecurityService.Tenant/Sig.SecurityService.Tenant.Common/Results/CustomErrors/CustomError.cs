using FluentResults;
using System.Text.Json;

namespace Sig.SecurityService.Tenant.Common.Results.CustomErrors;

public abstract class CustomError : Error
{
    private readonly string _code;
    private readonly string _message;
    private readonly string _source;

    protected CustomError(Type sourceType, string code, string message)
        : base(message)
    {
        _code = code;
        _message = message;
        _source = sourceType.Name;

        Metadata[nameof(_code)] = code;
        Metadata[nameof(_message)] = message;
        Metadata[nameof(_source)] = _source;
    }

    protected abstract object BuildToObject();

    public virtual object ToObject()
    {
        return new
        {
            Type = GetType().Name,
            ErrorDetail = BuildToObject(),
            Metadata = Metadata.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
        };
    }

    public override string ToString() =>
        JsonSerializer.Serialize(ToObject(), new JsonSerializerOptions { WriteIndented = true });
}

