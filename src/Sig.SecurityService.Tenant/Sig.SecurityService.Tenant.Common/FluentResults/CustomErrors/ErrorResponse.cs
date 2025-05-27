namespace Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;

public sealed record class ErrorResponse(
    string Code, 
    string Message, 
    List<string> Errors) { }
