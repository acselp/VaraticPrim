using VaraticPrim.Application.Contracts.Location;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Application.Mappers;

public static class LocationMapper
{
    public static LocationEntity ToEntity(this CreateLocationQuery query)
    {
        return new LocationEntity
        {
            CustomerId  = query.CustomerId,
            CounterList = query.CounterList.Select(CounterMapper.ToEntity).ToList(),
            Address     = query.Address?.ToEntity()
        };
    }
}