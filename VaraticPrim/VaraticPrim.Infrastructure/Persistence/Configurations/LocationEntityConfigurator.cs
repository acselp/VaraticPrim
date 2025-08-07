using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Infrastructure.Persistence.Configurations;

public class LocationEntityConfigurator : IEntityTypeConfiguration<LocationEntity>
{
    public void Configure(EntityTypeBuilder<LocationEntity> builder)
    {
        builder.ToTable("location", "public");

        builder.HasOne<AddressEntity>(x => x.Address)
               .WithOne(x => x.Location)
               .HasForeignKey<LocationEntity>(x => x.Id);

        builder.HasOne<CustomerEntity>(x => x.Customer)
               .WithOne(x => x.Location)
               .HasForeignKey<LocationEntity>(x => x.Id);
    }
}