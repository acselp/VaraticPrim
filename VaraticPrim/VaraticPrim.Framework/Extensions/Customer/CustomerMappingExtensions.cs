using VaraticPrim.Domain.Entities;
using VaraticPrim.Framework.Extensions.ContactInfo;
using VaraticPrim.Framework.Extensions.Location;
using VaraticPrim.Framework.Models.Customer;

namespace VaraticPrim.Framework.Extensions.Customer;

public static class CustomerMappingExtensions
{
    public static CustomerModel ToModel(this CustomerEntity entity)
    {
        return new CustomerModel
        {
            Id          = entity.Id,
            AccountNr   = entity.AccountNr,
            Location    = entity.Location?.ToModel(),
            ContactInfo = entity.ContactInfo?.ToModel()
        };
    }

    public static CustomerGridModel ToGridModel(this CustomerEntity entity)
    {
        return new CustomerGridModel
        {
            Id        = entity.Id,
            AccountNr = entity.AccountNr,
            Deleted   = entity.Deleted,
            FirstName = entity.ContactInfo?.FirstName ?? string.Empty,
            LastName  = entity.ContactInfo?.LastName  ?? string.Empty,
            Mobile    = entity.ContactInfo?.Mobile    ?? string.Empty,
            Phone     = entity.ContactInfo?.Phone     ?? string.Empty
        };
    }
}