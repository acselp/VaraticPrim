using Microsoft.Extensions.DependencyInjection;
using VaraticPrim.Application.Repository;

namespace VaraticPrim.Infrastructure.Repository;

public static class DependencyInjection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }
}