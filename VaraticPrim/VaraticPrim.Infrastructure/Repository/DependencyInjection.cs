using Microsoft.Extensions.DependencyInjection;
using VaraticPrim.Application.Repository;

namespace VaraticPrim.Infrastructure.Repository;

public static class DependencyInjection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ICounterRepository, CounterRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IContactInfoRepository, ContactInfoRepository>();
    }
}