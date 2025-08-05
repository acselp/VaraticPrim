using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VaraticPrim.Framework;
using VaraticPrim.Infrastructure.Options;
using VaraticPrim.Infrastructure.Persistence;
using VaraticPrim.Infrastructure.Repository;
using VaraticPrim.JwtAuth;
using VaraticPrim.Migrations.Evolve;

namespace VaraticPrim.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddControllers(options =>
                 {
                     var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                     options.Filters.Add(new AuthorizeFilter(policy));
                 })
                .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; });

        services.AddJwt(configuration);
        services.AddAuthorization();

        services.AddOptions(configuration);
        services.AddOptions();
        services.AddMigrations(configuration);
        services.AddFramework();
        services.AddRepositories();
        services.AddDbContext(configuration.GetConnectionString("PostgresConnection"));
    }

    private static void AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DbConnectionStringOptions>(configuration.GetSection(DbConnectionStringOptions.SectionName));
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
    }
}