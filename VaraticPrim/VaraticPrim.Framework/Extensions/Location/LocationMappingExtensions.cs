using VaraticPrim.Domain.Entities;
using VaraticPrim.Framework.Extensions.Address;
using VaraticPrim.Framework.Extensions.Counter;
using VaraticPrim.Framework.Extensions.Customer;
using VaraticPrim.Framework.Models.Location;

namespace VaraticPrim.Framework.Extensions.Location;

public static class LocationMappingExtensions
{
    public static LocationModel ToModel(this LocationEntity entity)
    {
        return new LocationModel
        {
            Id          = entity.Id,
            Customer    = entity.Customer.ToModel(),
            Address     = entity.Address.ToModel(),
            CounterList = entity.CounterList.Select(x => x.ToModel())
        };
    }
}