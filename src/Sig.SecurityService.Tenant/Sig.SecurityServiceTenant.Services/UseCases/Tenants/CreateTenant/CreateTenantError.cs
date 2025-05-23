using Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;
using Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors.Errors;
using Sig.SecurityServiceTenant.Services.Errors;

namespace Sig.SecurityServiceTenant.Services.UseCases.Tenants.CreateTenant;

public class CreateTenantError : CustomError
{
    public const string DocumentExistCode = "001";

    public CreateTenantError(string code, string message)
        : base("CreateTenantError", typeof(CreateTenantError), code, message)
    {
        //WithMetadata("step", "CreateAddressCommand");
        //WithMetadata("request", request);
        //WithMetadata("timestamp", DateTime.UtcNow);
        //WithMetadata("logs", "Falha ao criar endereço no fluxo CreateTenant");
    }

    public static ErrorException DocumentExist(string document)
        => new ErrorException(new CreateTenantError(DocumentExistCode, $"Document '{document}' exist"));

    public static ErrorException EmailExist(string email)
        => new ErrorException(new CreateTenantError(DocumentExistCode, $"Email '{email}' exist"));

    public static CreateTenantError PlanIdNotExist(Guid id)
        => new (DocumentExistCode, $"PlanId '{id}' not exist");
}
