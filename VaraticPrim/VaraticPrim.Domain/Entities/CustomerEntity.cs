namespace VaraticPrim.Domain.Entities;

public class CustomerEntity : BaseEntity
{
    public         int               ContactInfoId { get; set; }
    public virtual ContactInfoEntity ContactInfo   { get; set; }
    public         int               LocationId    { get; set; }
    public virtual LocationEntity    Location      { get; set; }
}