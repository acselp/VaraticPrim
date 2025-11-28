using VaraticPrim.Application.Contracts.Counter;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Application.Mappers;

public static class CounterMapper
{
    public static CounterEntity ToEntity(this UpdateCounterQuery counter)
    {
        return new CounterEntity
        {
            ReadingValue = counter.ReadingValue,
            Barcode      = counter.Barcode,
            UsageType    = counter.UsageType,
            LocationId   = counter.LocationId
        };
    }

    public static UpdateCounterResult ToUpdateResult(this CounterEntity counter)
    {
        return new UpdateCounterResult
        {
            Id           = counter.Id,
            ReadingValue = counter.ReadingValue,
            Barcode      = counter.Barcode,
            UsageType    = counter.UsageType,
            LocationId   = counter.LocationId
        };
    }
}