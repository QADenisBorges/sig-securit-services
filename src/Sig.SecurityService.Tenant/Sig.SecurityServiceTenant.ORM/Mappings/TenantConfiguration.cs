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

        builder.Property(t => t.CreatedAt).IsRequired();
        builder.Property(t => t.IsActive).IsRequired();
        builder.Property(t => t.SubscriptionStatus).IsRequired();

        builder.Property(t => t.CreateByUserId)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.CreateByUserName)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(t => t.CreatedByUser)
            .WithMany(p => p.CreatedTenants)
            .HasForeignKey(t => t.CreateByUserId);

        builder.OwnsOne(t => t.Document, doc =>
        {
            doc.Property(d => d.Number)
                .HasColumnName("DocumentNumber")
                .HasMaxLength(18)
                .IsRequired();

            doc.Ignore(d => d.Type);
        });

        builder.OwnsOne(t => t.Email, email =>
        {
            email.Property(e => e.Address)
                .HasColumnName("EmailAddress")
                .HasMaxLength(150)
                .IsRequired();
        });

        builder.OwnsOne(t => t.Phone, phone =>
        {
            phone.Property(p => p.Number)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(20)
                .IsRequired();
        });

        builder.OwnsOne(t => t.WhatsappPhone, phone =>
        {
            phone.Property(p => p.Number)
                .HasColumnName("WhatsappNumber")
                .HasMaxLength(20);
        });
    }
}
