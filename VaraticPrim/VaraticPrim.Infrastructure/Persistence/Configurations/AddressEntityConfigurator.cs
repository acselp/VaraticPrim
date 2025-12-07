using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Infrastructure.Persistence.Configurations;

public class AddressEntityConfigurator : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.ToTable("address", "public");

        builder.HasOne<CustomerEntity>(x => x.Customer)
               .WithOne(x => x.Address)
               .HasForeignKey<AddressEntity>(x => x.CustomerId);

        builder
           .Property(x => x.Street)
           .HasMaxLength(255);

        builder
           .Property(x => x.House)
           .HasMaxLength(50);

        builder
           .Property(x => x.Block)
           .HasMaxLength(50);

        builder
           .Property(x => x.Country)
           .HasMaxLength(50);

        builder
           .Property(x => x.Region)
           .HasMaxLength(50);

        builder
           .Property(x => x.Entrance)
           .HasMaxLength(50);

        builder
           .Property(x => x.City)
           .HasMaxLength(50);

        builder
           .Property(x => x.Apartment)
           .HasMaxLength(50);

        builder
           .Property(x => x.PostalCode)
           .HasMaxLength(50);
    }
}