using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VaraticPrim.Infrastructure.Options;

namespace VaraticPrim.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DbConnectionStringOptions>(dbOptions => configuration.GetSection(dbOptions.SectionName));
    }
}