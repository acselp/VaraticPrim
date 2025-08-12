namespace VaraticPrim.Domain.Entities;

public class CustomerEntity : BaseEntity
{
    public         int               AccountNr     { get; set; }
    public virtual ContactInfoEntity? ContactInfo   { get; set; }
    public virtual LocationEntity?    Location      { get; set; }
}