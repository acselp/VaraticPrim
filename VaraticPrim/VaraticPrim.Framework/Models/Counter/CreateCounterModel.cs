namespace VaraticPrim.Framework.Models.Counter;

public class CreateCounterModel
{
    public int    ReadingValue { get; set; }
    public string Barcode      { get; set; }
    public int    UsageType    { get; set; }
    public int    LocationId   { get; set; }
}