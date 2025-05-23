using Sig.SecurityServiceTenant.Domain.Entities.Base;
using Sig.SecurityServiceTenant.Domain.Enuns;
using Sig.SecurityServiceTenant.Domain.ValueObjects;

namespace Sig.SecurityServiceTenant.Domain.Entities;

public class Tenant : BaseEntity
{
    public required string Name { get; set; }
    public required Document Document { get; set; }
    public required Email Email { get; set; }
    public required Phone Phone { get; set; }
    public required Phone WhatsappPhone { get; set; }
    public required Address Address { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required bool IsActive { get; set; }
    public required Guid PlanId { get; set; }

    public Plan Plan { get; set; }
    public SubscriptionStatus SubscriptionStatus { get; set; }

    public Tenant()
    {
    }
}
