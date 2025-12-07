using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace NeoPay.Framework.Validators;

public static class DependencyInjection
{
    public static void AddValidators(this IServiceCollection services)
    {
        // services.AddValidatorsFromAssemblyContaining<UpdateCustomerModelValidator>();
    }
}