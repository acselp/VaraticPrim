namespace VaraticPrim.Domain.Entities;

public class ConsumptionRecord : BaseEntity
{
    public         float       AmountUsed { get; set; }
    public         int         MeterId    { get; set; }
    public virtual MeterEntity Meter      { get; set; } = null!;
}