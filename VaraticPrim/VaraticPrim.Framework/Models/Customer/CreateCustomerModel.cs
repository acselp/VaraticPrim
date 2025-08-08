using VaraticPrim.Framework.Models.ContactInfo;
using VaraticPrim.Framework.Models.Location;

namespace VaraticPrim.Framework.Models.Customer;

public class CreateCustomerModel
{
    public int                    AccountNr   { get; set; }
    public CreateContactInfoModel ContactInfo { get; set; }
    public CreateLocationModel    Location    { get; set; }
}