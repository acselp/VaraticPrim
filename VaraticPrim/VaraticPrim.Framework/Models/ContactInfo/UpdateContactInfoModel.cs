namespace VaraticPrim.Framework.Models.ContactInfo;

public class UpdateContactInfoModel
{
    public int     Id        { get; set; }
    public string  FirstName { get; set; }
    public string  LastName  { get; set; }
    public string? Phone     { get; set; }
    public string? Mobile    { get; set; }
}