using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VaraticPrim.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static void AddDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextPool<PostgresDbContext>(options => options
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention()
            .UseLazyLoadingProxies());
    }
}