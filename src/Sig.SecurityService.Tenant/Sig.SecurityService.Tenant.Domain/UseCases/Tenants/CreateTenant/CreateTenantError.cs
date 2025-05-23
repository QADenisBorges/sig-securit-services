using Sig.SecurityService.Tenant.Common.Results.CustomErrors;

namespace Sig.SecurityServiceTenant.Domain.UseCases.Tenants.CreateTenant;

public class CreateTenantError : CustomError
{
    public const string DocumentExistCode = "001";

    public CreateTenantError(string code, string message)
        : base(TypeErrorApplication.CreateTenant, typeof(CreateTenantError), code, message)
    {
        //WithMetadata("step", "CreateAddressCommand");
        //WithMetadata("request", request);
        //WithMetadata("timestamp", DateTime.UtcNow);
        //WithMetadata("logs", "Falha ao criar endereço no fluxo CreateTenant");
    }

    public static CreateTenantError DocumentExist(string document)
        => new(DocumentExistCode, $"Document '{document}' exist");

    public static CreateTenantError EmailExist(string email)
        => new(DocumentExistCode, $"Email '{email}' exist");

    public static CreateTenantError PlanIdNotExist(Guid id)
        => new(DocumentExistCode, $"PlanId '{id}' not exist");
}
