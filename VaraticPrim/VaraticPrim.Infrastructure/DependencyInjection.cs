using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VaraticPrim.Framework;
using VaraticPrim.Framework.Filters;
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

        services.AddControllers(options => { options.Filters.Add<InternalServerErrorExceptionFilter>(); })
                .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; });

        services.AddJwt(configuration.GetSection("Jwt"));
        services.AddOptions(configuration);
        services.AddOptions();
        services.AddMigrations(configuration);
        services.AddFramework();
        services.AddRepositories();
        services.AddJwt(configuration);
        services.AddDbContext(configuration.GetConnectionString("PostgresConnection"));
        services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }));
    }

    private static void AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DbConnectionStringOptions>(configuration.GetSection(DbConnectionStringOptions.SectionName));
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
    }
}