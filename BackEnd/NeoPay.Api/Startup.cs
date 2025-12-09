using NeoPay.Framework.Middlewares;
using NeoPay.Infrastructure;

namespace NeoPay.Api;

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
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                                         name: "default",
                                         pattern: "{controller=Home}/{action=Index}/{id?}");

            // If you use attribute routing alongside, you still need this:
        });
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseCors("AllowFrontendCorsPolicy");
        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
    }
}