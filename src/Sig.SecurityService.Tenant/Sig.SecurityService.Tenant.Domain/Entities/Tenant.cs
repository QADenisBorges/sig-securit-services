using Sig.SecurityServiceTenant.Domain.Enuns;
using Sig.SecurityServiceTenant.Domain.ObjectValues;

namespace Sig.SecurityServiceTenant.Domain.Entities;

public class Tenant
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Document Document { get; set; }
    public Email Email { get; set; }
    public Phone Phone { get; set; }
    public Phone? WhatsappPhone { get; set; }
    public Address? Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
    public Guid? PlanId { get; set; }
    public Plan? Plan { get; set; }
    public SubscriptionStatus SubscriptionStatus { get; set; }
}
