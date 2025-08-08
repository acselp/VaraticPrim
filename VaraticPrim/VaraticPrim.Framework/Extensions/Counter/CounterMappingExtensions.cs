using VaraticPrim.Domain.Entities;
using VaraticPrim.Framework.Extensions.Location;
using VaraticPrim.Framework.Models.Counter;

namespace VaraticPrim.Framework.Extensions.Counter;

public static class CounterMappingExtensions
{
    public static CounterEntity ToEntity(this CreateCounterModel model)
    {
        return new CounterEntity
        {
            LocationId   = model.LocationId,
            ReadingValue = model.ReadingValue,
            UsageType    = model.UsageType,
            Barcode      = model.Barcode
        };
    }

    public static CounterModel ToModel(this CounterEntity entity)
    {
        return new CounterModel
        {
            Id           = entity.Id,
            LocationId   = entity.LocationId,
            ReadingValue = entity.ReadingValue,
            UsageType    = entity.UsageType,
            Barcode      = entity.Barcode,

            Location = entity.Location.ToModel()
        };
    }
}