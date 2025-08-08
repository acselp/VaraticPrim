using FluentValidation;
using VaraticPrim.Framework.Models.Address;

namespace VaraticPrim.Framework.Validators;

public class CreateAddressModelValidator : AbstractValidator<CreateAddressModel>
{
    public CreateAddressModelValidator()
    {
        RuleFor(x => x.Street)
           .MaximumLength(255).WithMessage("Street length must be less than 255 characters");

        RuleFor(x => x.HouseNr)
           .MaximumLength(50).WithMessage("House Number length must be less than 50 characters");

        RuleFor(x => x.Block)
           .MaximumLength(50).WithMessage("Block length must be less than 50 characters");

        RuleFor(x => x.Entrance)
           .MaximumLength(50).WithMessage("Entrance length must be less than 50 characters");

        RuleFor(x => x.ApartmentNr)
           .MaximumLength(50).WithMessage("ApartmentNr length must be less than 50 characters");

        RuleFor(x => x.Locality)
           .MaximumLength(50).WithMessage("Locality length must be less than 50 characters");

        RuleFor(x => x.District)
           .MaximumLength(50).WithMessage("District length must be less than 50 characters");

        RuleFor(x => x.PostalCode)
           .MaximumLength(50).WithMessage("Postal Code length must be less than 50 characters");

        RuleFor(x => x.Country)
           .MaximumLength(50).WithMessage("Country length must be less than 50 characters");
    }
}