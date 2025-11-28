namespace VaraticPrim.Application.Contracts.ContactInfo;

public class CreateContactInfoResult
{
    public int     Id         { get; set; }
    public string  FirstName  { get; set; }
    public string  LastName   { get; set; }
    public string? Phone      { get; set; }
    public string? Mobile     { get; set; }
    public int     CustomerId { get; set; }
}