using FluentValidation;
using VaraticPrim.Framework.Models.Auth;

namespace VaraticPrim.Framework.Validators;

public class LoginModelValidator : AbstractValidator<LoginModel>
{
    public LoginModelValidator()
    {
        RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email should not be empty.")
           .EmailAddress().WithMessage("Please insert a valid email address.");

        RuleFor(x => x.Password)
           .NotEmpty().WithMessage("Password should not be empty.");
    }
}