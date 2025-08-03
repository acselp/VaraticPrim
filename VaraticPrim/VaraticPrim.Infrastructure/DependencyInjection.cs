using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VaraticPrim.Framework;
using VaraticPrim.Framework.Errors.Filters;
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
        
        services.AddOptions(configuration);
        
        services.AddMvc(options =>
                        {
                            options.Filters.Add<InternalServerErrorExceptionFilter>();
                        });
        services.AddMigrations(configuration);
        services.AddFramework();
        services.AddJwt(configuration);
        services.AddDbContext(configuration.GetConnectionString("PostgresConnection"));
        services.AddRepositories();
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