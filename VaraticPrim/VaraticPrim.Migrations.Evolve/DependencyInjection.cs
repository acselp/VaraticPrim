using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VaraticPrim.Migrations.Evolve;

public static class DependencyInjection
{
    public static void AddMigrations(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(new EvolveMigrationRunner(configuration.GetConnectionString("PostgresConnection") ?? string.Empty));

        using (ServiceProvider serviceProvider = services.BuildServiceProvider())
        {
            var migrationRunner = serviceProvider.GetService<EvolveMigrationRunner>();
            migrationRunner.Migrate();
        }
    }
}