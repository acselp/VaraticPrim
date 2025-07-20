using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VaraticPrim.Infrastructure.Options;
using VaraticPrim.Infrastructure.Persistence;
using VaraticPrim.Infrastructure.Repository;

namespace VaraticPrim.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DbConnectionStringOptions>(dbOptions => configuration.GetSection(dbOptions.SectionName));
        
        services.AddDbContext(configuration.GetConnectionString("PostgresConnection"));
        services.AddRepositories();
    }
}