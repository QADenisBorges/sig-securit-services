namespace Sig.SecurityServiceTenant.Domain.Entities;

public class Plan
{

    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required decimal MonthlyPrice { get; set; }
    public required int MaxUsers { get; set; }

    public required ICollection<Tenant> Tenants { get; set; }
    public Plan()
    {
    }
}
