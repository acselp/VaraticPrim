using VaraticPrim.Application.Contracts.Location;
using VaraticPrim.Framework.Models.Location;

namespace VaraticPrim.Framework.Mappers;

public static class LocationMapper
{
    public static UpdateLocationQuery ToQuery(this UpdateLocationModel model)
    {
        return new UpdateLocationQuery
        {
            CustomerId  = model.CustomerId,
            Address     = model.Address?.ToQuery(),
            CounterList = model.CounterList.Select(CounterMapper.ToQuery)
        };
    }

    public static LocationModel ToModel(this UpdateLocationResult model)
    {
        return new LocationModel
        {
            Id          = model.Id,
            CustomerId  = model.CustomerId,
            Address     = model.Address?.ToModel(),
            CounterList = model.CounterList.Select(CounterMapper.ToModel)
        };
    }

    public static LocationModel ToModel(this GetLocationResult model)
    {
        return new LocationModel
        {
            Id          = model.Id,
            CustomerId  = model.CustomerId,
            Address     = model.Address?.ToModel(),
            CounterList = model.CounterList.Select(CounterMapper.ToModel)
        };
    }
}