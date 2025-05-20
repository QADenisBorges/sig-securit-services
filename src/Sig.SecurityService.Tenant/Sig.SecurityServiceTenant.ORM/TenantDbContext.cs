using Microsoft.EntityFrameworkCore;
using Sig.SecurityServiceTenant.Domain.Entities;
using Sig.SecurityServiceTenant.ORM.Mappings;

namespace Sig.SecurityServiceTenant.ORM;

public class TenantDbContext : DbContext
{
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Plan> Plans { get; set; }

    public TenantDbContext(DbContextOptions<TenantDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TenantConfiguration());
        modelBuilder.ApplyConfiguration(new PlanConfiguration());
    }
}



