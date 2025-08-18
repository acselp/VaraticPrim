using VaraticPrim.Framework.Middlewares;
using VaraticPrim.Infrastructure;

namespace VaraticPrim.Api;

public class Startup
{
    private readonly IConfiguration _config;

    public Startup(IConfiguration configuration)
    {
        _config = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddInfrastructure(_config);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors("AllowFrontendCorsPolicy");
        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}