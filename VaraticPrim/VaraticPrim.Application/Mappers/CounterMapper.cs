using VaraticPrim.Application.Contracts.Counter;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Application.Mappers;

public static class CounterMapper
{
    public static CounterEntity ToEntity(this CreateCounterQuery counter)
    {
        return new CounterEntity
        {
            ReadingValue = counter.ReadingValue,
            Barcode      = counter.Barcode,
            UsageType    = counter.UsageType,
            LocationId   = counter.LocationId
        };
    }
}