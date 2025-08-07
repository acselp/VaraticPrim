using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Infrastructure.Persistence.Configurations;

public class ContactInfoEntityConfigurator : IEntityTypeConfiguration<ContactInfoEntity>
{
    public void Configure(EntityTypeBuilder<ContactInfoEntity> builder)
    {
        builder.ToTable("contact_info", "public");

        builder.HasOne<CustomerEntity>(x => x.Customer)
               .WithOne(x => x.ContactInfo)
               .HasForeignKey<CustomerEntity>(x => x.Id);

        builder
           .Property(x => x.FirstName)
           .HasMaxLength(100)
           .HasDefaultValue("");

        builder
           .Property(x => x.LastName)
           .HasMaxLength(100)
           .HasDefaultValue("");

        builder
           .Property(x => x.Phone)
           .HasMaxLength(50)
           .HasDefaultValue("");

        builder
           .Property(x => x.Mobile)
           .HasMaxLength(50)
           .HasDefaultValue("");
    }
}