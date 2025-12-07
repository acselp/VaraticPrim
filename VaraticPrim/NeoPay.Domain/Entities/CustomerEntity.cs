namespace NeoPay.Domain.Entities;

public class CustomerEntity : BaseEntity
{
    public         string        FirstName { get; set; } = null!;
    public         string        LastName  { get; set; } = null!;
    public         string?       Email     { get; set; }
    public         string?       Phone     { get; set; }
    public         int           AccountNr { get; set; }
    public virtual AddressEntity Address   { get; set; } = null!;
    public virtual ICollection<ConnectionEntity> Connections { get; set; } = new List<ConnectionEntity>();
}