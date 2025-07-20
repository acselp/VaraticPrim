using VaraticPrim.Framework;
using VaraticPrim.Infrastructure;
using VaraticPrim.Migrations.Evolve;

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

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddEndpointsApiExplorer();
            services.AddInfrastructure(_config);
            services.AddMigrations(_config);
            services.AddFramework();
            
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
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
            app.UseCors("MyPolicy");
        }
    } 
}