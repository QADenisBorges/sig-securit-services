using Sig.SecurityServiceTenant.Domain.Enuns;
using Sig.SecurityServiceTenant.Domain.ObjectValues;

namespace Sig.SecurityServiceTenant.Domain.Entities;

public class Tenant
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required Document Document { get; set; }
    public required Email Email { get; set; }
    public required Phone Phone { get; set; }
    public Phone? WhatsappPhone { get; set; }
    public Address? Address { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required bool IsActive { get; set; }
    public Guid? PlanId { get; set; }
    public Plan? Plan { get; set; }
    public SubscriptionStatus SubscriptionStatus { get; set; }
    public Tenant()
    {
    }
}
