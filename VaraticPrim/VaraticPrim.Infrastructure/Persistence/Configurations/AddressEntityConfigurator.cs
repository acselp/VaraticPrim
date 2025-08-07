using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Infrastructure.Persistence.Configurations;

public class AddressEntityConfigurator : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.ToTable("address", "public");

        builder.HasOne<LocationEntity>(x => x.Location)
               .WithOne(x => x.Address)
               .HasForeignKey<LocationEntity>(x => x.Id);

        builder
           .Property(x => x.Street)
           .HasMaxLength(255)
           .HasDefaultValue("");

        builder
           .Property(x => x.HouseNr)
           .HasMaxLength(50)
           .HasDefaultValue("");

        builder
           .Property(x => x.Block)
           .HasMaxLength(50)
           .HasDefaultValue("");

        builder
           .Property(x => x.Country)
           .HasMaxLength(50)
           .HasDefaultValue("");

        builder
           .Property(x => x.District)
           .HasMaxLength(50)
           .HasDefaultValue("");

        builder
           .Property(x => x.Entrance)
           .HasMaxLength(50)
           .HasDefaultValue("");

        builder
           .Property(x => x.Locality)
           .HasMaxLength(50)
           .HasDefaultValue("");

        builder
           .Property(x => x.ApartmentNr)
           .HasMaxLength(50)
           .HasDefaultValue("");

        builder
           .Property(x => x.PostalCode)
           .HasMaxLength(50)
           .HasDefaultValue("");
    }
}