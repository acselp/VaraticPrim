namespace VaraticPrim.Domain.Entities;

public class ContactInfoEntity : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName  { get; set; }
    public string Phone     { get; set; }
    public string Mobile    { get; set; }

    public virtual CustomerEntity Customer { get; set; }
}