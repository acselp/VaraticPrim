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
               .HasForeignKey<AddressEntity>(x => x.LocationId);
        
        builder.HasMany(x => x.CounterList)
            .WithOne(x => x.Location)
            .HasForeignKey(x => x.LocationId);
    }
}