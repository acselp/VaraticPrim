namespace VaraticPrim.Domain.Entities;

public class LocationEntity : BaseEntity
{
    public         int                        CustomerId  { get; set; }
    public virtual AddressEntity?             Address     { get; set; } = new();
    public virtual CustomerEntity             Customer    { get; set; }
    public virtual IEnumerable<CounterEntity> CounterList { get; set; } = new List<CounterEntity>();
}