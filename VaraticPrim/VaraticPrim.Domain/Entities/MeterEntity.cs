namespace VaraticPrim.Domain.Entities;

public class MeterEntity : BaseEntity
{
    public         string           SerialNumber { get; set; } = null!;
    public         int              Status       { get; set; }
    public         int              ConnectionId { get; set; }
    public virtual ConnectionEntity Connection   { get; set; } = null!;
}