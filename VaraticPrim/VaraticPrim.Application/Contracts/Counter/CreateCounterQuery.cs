namespace VaraticPrim.Application.Contracts.Counter;

public class CreateCounterQuery
{
    public int    ReadingValue { get; set; }
    public string Barcode      { get; set; }
    public int    UsageType    { get; set; }
    public int    LocationId   { get; set; }
}