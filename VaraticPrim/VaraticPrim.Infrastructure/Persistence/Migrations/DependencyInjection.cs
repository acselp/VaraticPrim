using Microsoft.Extensions.DependencyInjection;
using VaraticPrim.Infrastructure.Persistence.Migrations.Evolve;

namespace VaraticPrim.Infrastructure.Persistence.Migrations;

public static class DependencyInjection
{
    public static void AddMigrations(this IServiceCollection services)
    {
        services.AddSingleton<IMigrationRunner, EvolveMigrationRunner>();
    }
}