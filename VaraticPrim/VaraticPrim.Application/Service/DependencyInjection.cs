using Microsoft.Extensions.DependencyInjection;

namespace VaraticPrim.Application.Service;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<CustomerService>();
    }
}