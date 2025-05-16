namespace Sig.SecurityServiceTenant.Domain.Entities;

public class Plan
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal MonthlyPrice { get; set; }
    public int MaxUsers { get; set; }

    public ICollection<Tenant> Tenants { get; set; }
}
