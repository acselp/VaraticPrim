namespace VaraticPrim.Domain.Entities;

public class Customer : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int NrCarnet { get; set; }
    public int RoleId { get; set; }
}