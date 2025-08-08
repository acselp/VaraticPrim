using VaraticPrim.Framework.Models.Location;
using VaraticPrim.Framework.Models.Shared;

namespace VaraticPrim.Framework.Models.Counter;

public class CounterModel : BaseReadModel
{
    public int    ReadingValue { get; set; }
    public string Barcode      { get; set; }
    public int    UsageType    { get; set; }
    public int    LocationId   { get; set; }

    public LocationModel Location { get; set; }
}