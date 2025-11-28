using FluentValidation;
using VaraticPrim.Framework.Models.Customer;

namespace VaraticPrim.Framework.Validators;

public class UpdateCustomerModelValidator : AbstractValidator<UpdateCustomerModel>
{
    public UpdateCustomerModelValidator()
    {
        RuleFor(x => x.AccountNr)
           .NotEmpty().WithMessage("Account Nr is required.");
    }
}