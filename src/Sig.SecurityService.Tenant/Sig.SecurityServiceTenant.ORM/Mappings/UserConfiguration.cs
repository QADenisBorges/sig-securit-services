using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sig.SecurityServiceTenant.Domain.Entities;

namespace Sig.SecurityServiceTenant.ORM.Mappings;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.Property(u => u.Id)
       .HasColumnType("uniqueidentifier")
       .ValueGeneratedNever(); 


        builder.Property(u => u.Username)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(u => u.Password)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.Phone)
               .HasMaxLength(20);

        builder.Property(u => u.Status)
               .HasConversion<string>()
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(u => u.Role)
               .HasConversion<string>()
               .HasMaxLength(20)
               .IsRequired();
    }
}

