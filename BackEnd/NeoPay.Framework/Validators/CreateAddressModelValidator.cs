using FluentValidation;
using NeoPay.Framework.Models.Address;

namespace NeoPay.Framework.Validators;

public class CreateAddressModelValidator : AbstractValidator<CreateAddressModel>
{
    public CreateAddressModelValidator()
    {
        RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Customer ID is required.");
    }
}
