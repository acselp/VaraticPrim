using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Infrastructure.Persistence.Configurations;

public class RefreshTokenEntityConfigurator : IEntityTypeConfiguration<RefreshTokenEntity>
{
    public void Configure(EntityTypeBuilder<RefreshTokenEntity> builder)
    {
        builder.ToTable("refresh_token", "public");

        builder.HasOne<UserEntity>(u => u.UserEntity)
               .WithMany()
               .HasForeignKey(u => u.UserId);
    }
}