using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sig.SecurityServiceTenant.Domain.Entities;

namespace Sig.SecurityServiceTenant.ORM.Mappings;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("Tenants");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.CreatedAt)
            .IsRequired();

        builder.Property(t => t.IsActive)
            .IsRequired();

        builder.Property(t => t.SubscriptionStatus)
            .IsRequired();

        builder.HasOne(t => t.Plan)
            .WithMany(p => p.Tenants)
            .HasForeignKey(t => t.PlanId);

        builder.OwnsOne(t => t.Document, doc =>
        {
            doc.Property(d => d.Number)
                .HasMaxLength(18)
                .IsRequired();

            doc.Property(d => d.Type)
                .IsRequired();

            doc.WithOwner();
        });

        builder.OwnsOne(t => t.Email, email =>
        {
            email.Property(e => e.Address)
                .HasMaxLength(150)
                .IsRequired();

            email.WithOwner();
        });

        builder.OwnsOne(t => t.Phone, phone =>
        {
            phone.Property(p => p.Number)
                .HasMaxLength(20)
                .IsRequired();

            phone.WithOwner();
        });

        builder.OwnsOne(t => t.WhatsappPhone, phone =>
        {
            phone.Property(p => p.Number)
                .HasMaxLength(20);

            phone.WithOwner();
        });

        builder.OwnsOne(t => t.Address, addr =>
        {
            addr.Property(a => a.Street).HasMaxLength(100);
            addr.Property(a => a.Number).HasMaxLength(20);
            addr.Property(a => a.Complement).HasMaxLength(50);
            addr.Property(a => a.District).HasMaxLength(50);
            addr.Property(a => a.City).HasMaxLength(80);
            addr.Property(a => a.State).HasMaxLength(2);
            addr.Property(a => a.PostalCode).HasMaxLength(9); 

            addr.WithOwner();
        });
    }
}
