namespace NeoPay.Domain.Entities;

public class ConsumptionRecord : BaseEntity
{
    public         decimal    AmountUsed { get; set; }
    public         int         MeterId    { get; set; }
    public virtual MeterEntity Meter      { get; set; } = null!;
}