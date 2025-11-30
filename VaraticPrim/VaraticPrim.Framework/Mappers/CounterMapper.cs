using VaraticPrim.Application.Contracts.Counter;
using VaraticPrim.Framework.Models.Counter;

namespace VaraticPrim.Framework.Mappers;

public static class CounterMapper
{
    public static UpdateCounterQuery ToQuery(this UpdateCounterModel model)
    {
        return new UpdateCounterQuery
        {
            Id           = model.Id,
            LocationId   = model.LocationId,
            Barcode      = model.Barcode,
            ReadingValue = model.ReadingValue,
            UsageType    = model.UsageType
        };
    }

    public static CounterModel ToModel(this UpdateCounterResult model)
    {
        return new CounterModel
        {
            Id           = model.Id,
            LocationId   = model.LocationId,
            Barcode      = model.Barcode,
            ReadingValue = model.ReadingValue,
            UsageType    = model.UsageType
        };
    }

    public static CounterModel ToModel(this GetCounterResult model)
    {
        return new CounterModel
        {
            Id           = model.Id,
            LocationId   = model.LocationId,
            Barcode      = model.Barcode,
            ReadingValue = model.ReadingValue,
            UsageType    = model.UsageType
        };
    }
}