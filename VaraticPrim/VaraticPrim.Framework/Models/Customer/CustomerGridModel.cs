namespace VaraticPrim.Framework.Models.Customer;

public class CustomerGridModel
{
    public int    Id        { get; set; }
    public int    AccountNr { get; set; }
    public bool   Deleted   { get; set; }
    public string FirstName { get; set; }
    public string LastName  { get; set; }
    public string Phone     { get; set; }
    public string Mobile    { get; set; }
}