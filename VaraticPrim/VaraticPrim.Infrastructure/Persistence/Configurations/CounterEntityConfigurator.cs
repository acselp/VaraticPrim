using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Infrastructure.Persistence.Configurations;

public class CounterEntityConfigurator : IEntityTypeConfiguration<CounterEntity>
{
    public void Configure(EntityTypeBuilder<CounterEntity> builder)
    {
        builder.ToTable("counter", "public");

        builder.HasOne<LocationEntity>(x => x.Location)
               .WithMany(x => x.CounterList)
               .HasForeignKey(x => x.LocationId);

        builder
           .Property(x => x.Barcode)
           .HasMaxLength(50)
           .HasDefaultValue("");

        builder
           .Property(x => x.ReadingValue)
           .HasDefaultValue(0);

        builder
           .Property(x => x.UsageType)
           .HasDefaultValue(0);
    }
}