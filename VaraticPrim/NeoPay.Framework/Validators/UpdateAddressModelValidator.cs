using FluentValidation;
using NeoPay.Framework.Models.Address;

namespace NeoPay.Framework.Validators;

public class UpdateAddressModelValidator : AbstractValidator<UpdateAddressModel>
{
    public UpdateAddressModelValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Address ID is required.");
        RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Customer ID is required.");
    }
}
