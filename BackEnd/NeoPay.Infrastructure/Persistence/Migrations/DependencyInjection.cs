using Microsoft.Extensions.DependencyInjection;
using NeoPay.Infrastructure.Persistence.Migrations.Evolve;

namespace NeoPay.Infrastructure.Persistence.Migrations;

public static class DependencyInjection
{
    public static void AddMigrations(this IServiceCollection services)
    {
        services.AddSingleton<IMigrationRunner, EvolveMigrationRunner>();
    }
}