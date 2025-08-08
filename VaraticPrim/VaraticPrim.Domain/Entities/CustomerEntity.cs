namespace VaraticPrim.Domain.Entities;

public class CustomerEntity : BaseEntity
{
    public         int               AccountNr     { get; set; }
    public         int               ContactInfoId { get; set; }
    public         int               LocationId    { get; set; }
    public virtual ContactInfoEntity ContactInfo   { get; set; }
    public virtual LocationEntity    Location      { get; set; }
}