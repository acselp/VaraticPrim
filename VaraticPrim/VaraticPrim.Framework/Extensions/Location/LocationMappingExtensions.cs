using VaraticPrim.Application.Contracts.Location;
using VaraticPrim.Application.Mappers;
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
            CustomerId  = entity.CustomerId,
            Customer    = entity.Customer.ToModel(),
            Address     = entity.Address?.ToModel(),
            CounterList = entity.CounterList.Select(x => x.ToModel())
        };
    }

    public static UpdateLocationResult ToUpdateResult(this LocationEntity entity)
    {
        return new UpdateLocationResult
        {
            Id          = entity.Id,
            CustomerId  = entity.CustomerId,
            Address     = entity.Address?.ToUpdateResult(),
            CounterList = entity.CounterList.Select(x => x.ToUpdateResult())
        };
    }
}