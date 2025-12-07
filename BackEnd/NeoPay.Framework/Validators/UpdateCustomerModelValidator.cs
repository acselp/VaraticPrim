using FluentValidation;
using NeoPay.Framework.Models.Customer;

namespace NeoPay.Framework.Validators;

public class UpdateCustomerModelValidator : AbstractValidator<UpdateCustomerModel>
{
    public UpdateCustomerModelValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Customer ID is required.");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x.Email)).WithMessage("Invalid email format.");
        RuleFor(x => x.AccountNr).NotEmpty().WithMessage("Account number is required.");
    }
}
