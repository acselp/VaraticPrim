using FluentValidation;
using VaraticPrim.Framework.Models.Customer;

namespace VaraticPrim.Framework.Validators;

public class CreateCustomerModelValidator : AbstractValidator<CreateCustomerModel>
{
    public CreateCustomerModelValidator()
    {
        RuleFor(x => x.AccountNr)
           .NotEmpty().WithMessage("Account Nr is required.");
    }
}