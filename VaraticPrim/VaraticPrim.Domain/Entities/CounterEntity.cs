namespace VaraticPrim.Domain.Entities;

public class CounterEntity : BaseEntity
{
    public         int            ReadingValue { get; set; }
    public         string         Barcode      { get; set; }
    public         int            UsageType    { get; set; }
    public         int            LocationId   { get; set; }
    public virtual LocationEntity Location     { get; set; }
}