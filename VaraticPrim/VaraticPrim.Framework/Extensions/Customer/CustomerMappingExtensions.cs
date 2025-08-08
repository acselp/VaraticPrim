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
            AccountNr   = entity.AccountNr,
            Location    = entity.Location.ToModel(),
            ContactInfo = entity.ContactInfo.ToModel()
        };
    }
}