using Microsoft.EntityFrameworkCore;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Infrastructure.Persistence;

public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity>         UserTable         { get; set; }
    public DbSet<RefreshTokenEntity> RefreshTokenTable { get; set; }
}