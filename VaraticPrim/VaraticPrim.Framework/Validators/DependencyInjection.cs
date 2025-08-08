using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace VaraticPrim.Framework.Validators;

public static class DependencyInjection
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateUserModelValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateAddressModelValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateContactInfoModelValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateCustomerModelValidator>();
    }
}