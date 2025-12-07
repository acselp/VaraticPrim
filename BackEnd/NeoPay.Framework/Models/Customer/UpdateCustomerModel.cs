namespace NeoPay.Framework.Models.Customer;

public class UpdateCustomerModel
{
    public int     Id        { get; set; }
    public string  FirstName { get; set; } = null!;
    public string  LastName  { get; set; } = null!;
    public string? Email     { get; set; }
    public string? Phone     { get; set; }
    public int     AccountNr { get; set; }
}
