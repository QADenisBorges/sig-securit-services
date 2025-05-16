using FluentResults;
using FluentValidation.Results;
using System.Text.Json;

namespace Sig.SecurityService.Tenant.Common.Results.CustomErrors;

public class ExceptionError : CustomError
{
    private readonly string _message;
    private readonly List<IError> _errors;

    public ExceptionError(IReadOnlyCollection<IError> errors)
        : base(typeof(ExceptionError), "500", BuildSummaryMessage(errors))
    {
        _message = BuildSummaryMessage(errors);
        _errors = errors.ToList();
        Capture(errors);
    }

    public ExceptionError(Exception exception)
        : base(typeof(ExceptionError), "500", exception.Message)
    {
        _message = exception.Message;
        _errors = [];
        Metadata["ExceptionType"] = exception.GetType().Name;
        Metadata["Message"] = exception.Message;
        Metadata["Source"] = exception.Source ?? "Unknown";
        Metadata["StackTrace"] = exception.StackTrace ?? "No stack trace";
        if (exception.InnerException is not null)
            Metadata["InnerException"] = exception.InnerException.Message;
    }

    private void Capture(IEnumerable<IError> errors)
    {
        var list = errors.ToList();
        Metadata["TotalErrors"] = list.Count.ToString();

        for (int i = 0; i < list.Count; i++)
        {
            var error = list[i];
            var prefix = $"Errors[{i}]";

            Metadata[$"{prefix}.Type"] = error.GetType().Name;
            Metadata[$"{prefix}.Message"] = error.Message;

            foreach (var kvp in error.Metadata)
                Metadata[$"{prefix}.Metadata.{kvp.Key}"] = kvp.Value?.ToString() ?? "null";

            Reasons.Add(error);
        }
    }

    protected override object BuildToObject()
    {
        return new
        {
            Type = nameof(ExceptionError),
            Message = _message,
            Source = Metadata.TryGetValue("Source", out var source) ? source : "Exception",
            Errors = _errors.Select(e => new
            {
                Type = e.GetType().Name,
                e.Message,
                Metadata = e.Metadata.ToDictionary(m => m.Key, m => m.Value)
            }).ToList()
        };
    }

    private static string BuildSummaryMessage(IEnumerable<IError> errors)
        => string.Join(" | ", errors.Select(e => e.Message));
}

