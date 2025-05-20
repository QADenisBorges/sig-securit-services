using FluentValidation.Results;

namespace Sig.SecurityService.Tenant.Common.Results.CustomErrors;

public class ValidationError : CustomError
{
    private readonly IReadOnlyCollection<string> _errors;

    public ValidationError(IEnumerable<string> errors)
        : base(typeof(ValidationError), "1", "One or more validation errors occurred.")
    {
        _errors = errors.ToList().AsReadOnly();
        foreach (var error in _errors)
            Metadata.TryAdd($"ValidationError-{Guid.NewGuid()}", error);
    }

    public ValidationError(ValidationResult validationResult)
        : this(validationResult.Errors.Select(FormatValidationFailure))
    {
        foreach (var failure in validationResult.Errors)
            Metadata.TryAdd($"Property-{failure.PropertyName}", failure.ErrorMessage);
    }

    public override object ToObjectResponse()
    {
        return new
        {
            Type = nameof(ValidationError),
            Code = "1",
            Message = "One or more validation errors occurred.",
            Errors = _errors
        };
    }

    private static string FormatValidationFailure(ValidationFailure failure)
        => $"{failure.PropertyName}: {failure.ErrorMessage}";
}

