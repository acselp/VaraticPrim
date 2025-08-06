using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Infrastructure.Persistence.Configurations;

public class UserEntityConfigurator : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("user", "public");
    }
}