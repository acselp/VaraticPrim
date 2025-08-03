using VaraticPrim.Framework;
using VaraticPrim.Infrastructure;
using VaraticPrim.Migrations.Evolve;
using Microsoft.IdentityModel.Tokens;
using VaraticPrim.Infrastructure.Options;
using VaraticPrim.JwtAuth;


namespace VaraticPrim.Api
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddInfrastructure(_config);
            services.AddOptions();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
                             {
                                 endpoints.MapControllers();
                             });

            app.UseCors("MyPolicy");
        }
    }
}