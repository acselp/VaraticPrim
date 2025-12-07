using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VaraticPrim.Infrastructure.Persistence.Migrations;

namespace VaraticPrim.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<PostgresDbContext>(options => options
                                                               .UseNpgsql(configuration
                                                                             .GetConnectionString("PostgresConnection"))
                                                               .UseSnakeCaseNamingConvention()
                                                               .UseLazyLoadingProxies());
        services.AddMigrations();
    }
}