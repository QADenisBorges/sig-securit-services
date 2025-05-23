using Sig.SecurityServiceTenant.Domain.Entities.Base;

namespace Sig.SecurityServiceTenant.Domain.Entities;

public class Plan : BaseEntity
{
    public required string Name { get; set; }
    public required decimal MonthlyPrice { get; set; }
    public required int MaxUsers { get; set; }

    public required ICollection<Tenant> Tenants { get; set; }
    public Plan()
    {
    }
}
