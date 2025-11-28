using VaraticPrim.Framework.Models.Customer;
using VaraticPrim.Framework.Models.Shared;

namespace VaraticPrim.Framework.Models.ContactInfo;

public class ContactInfoModel : BaseReadModel
{
    public string  FirstName { get; set; }
    public string  LastName  { get; set; }
    public string? Phone     { get; set; }
    public string? Mobile    { get; set; }

    public CustomerModel Customer { get; set; }
}