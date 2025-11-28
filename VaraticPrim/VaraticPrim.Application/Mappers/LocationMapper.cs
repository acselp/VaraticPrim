using VaraticPrim.Application.Contracts.Location;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Application.Mappers;

public static class LocationMapper
{
    public static LocationEntity ToEntity(this UpdateLocationQuery query)
    {
        return new LocationEntity
        {
            CustomerId  = query.CustomerId,
            CounterList = query.CounterList.Select(CounterMapper.ToEntity).ToList(),
            Address     = query.Address?.ToEntity()
        };
    }

    public static UpdateLocationResult ToUpdateResult(this LocationEntity entity)
    {
        return new UpdateLocationResult
        {
            CustomerId  = entity.CustomerId,
            CounterList = entity.CounterList.Select(CounterMapper.ToUpdateResult).ToList(),
            Address     = entity.Address?.ToUpdateResult()
        };
    }
}