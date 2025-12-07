namespace VaraticPrim.Domain.Entities;

public class UtilityEntity : BaseEntity
{
    public string Name     { get; set; } = null!;
    public int    UnitType { get; set; }
}