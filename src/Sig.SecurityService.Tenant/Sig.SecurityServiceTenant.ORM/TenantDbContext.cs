using Microsoft.EntityFrameworkCore;
using Sig.SecurityServiceTenant.Domain.Entities;
using Sig.SecurityServiceTenant.ORM.Mappings;

namespace Sig.SecurityServiceTenant.ORM;

public class TenantDbContext(DbContextOptions<TenantDbContext> options) : DbContext(options)
{
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TenantConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}



