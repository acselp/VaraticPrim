using Microsoft.EntityFrameworkCore;

namespace VaraticPrim.Infrastructure.Persistence;

public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}