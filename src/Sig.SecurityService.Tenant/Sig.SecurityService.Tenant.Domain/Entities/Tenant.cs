using Ambev.DeveloperEvaluation.Domain.Common;
using FluentResults;
using Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;
using Sig.SecurityServiceTenant.Domain.Enuns;
using Sig.SecurityServiceTenant.Domain.Validators;
using Sig.SecurityServiceTenant.Domain.ValueObjects;

namespace Sig.SecurityServiceTenant.Domain.Entities;

public class Tenant : BaseEntity
{
    public required string Name { get; set; }
    public required Document Document { get; set; }
    public required Email Email { get; set; }
    public required Phone Phone { get; set; }
    public required Phone WhatsappPhone { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required bool IsActive { get; set; }
    public required Guid CreateByUserId { get; set; }
    public required string CreateByUserName { get; set; }
    public User CreatedByUser { get; set; } = null!;
    public SubscriptionStatus SubscriptionStatus { get; set; }

    public Tenant()
    {
    }

    public Result IsValid()
    {
        var validator = new TenantValidator();

        var validationResult = validator.Validate(this);

        return validationResult.IsValid
            ? Result.Ok()
            : ValidatorFailure.Fail(validationResult.Errors);
    }
}
