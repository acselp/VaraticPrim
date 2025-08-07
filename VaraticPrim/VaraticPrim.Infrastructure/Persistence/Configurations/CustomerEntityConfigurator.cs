using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Infrastructure.Persistence.Configurations;

public class CustomerEntityConfigurator : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.ToTable("customer", "public");

        builder.HasOne<LocationEntity>(x => x.Location)
               .WithOne(x => x.Customer)
               .HasForeignKey<CustomerEntity>(x => x.Id);
    }
}