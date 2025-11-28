namespace VaraticPrim.Application.Contracts.ContactInfo;

public class UpdateContactInfoQuery
{
    public string  FirstName { get; set; }
    public string  LastName  { get; set; }
    public string? Phone     { get; set; }
    public string? Mobile    { get; set; }
}