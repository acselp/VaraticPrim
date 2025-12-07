using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeoPay.Infrastructure.Persistence.Migrations;

namespace NeoPay.Infrastructure.Persistence;

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