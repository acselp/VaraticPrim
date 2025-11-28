using VaraticPrim.Framework.Models.ContactInfo;
using VaraticPrim.Framework.Models.Location;

namespace VaraticPrim.Framework.Models.Customer;

public class UpdateCustomerModel
{
    public int                    Id          { get; set; }
    public int                    AccountNr   { get; set; }
    public UpdateContactInfoModel ContactInfo { get; set; } = new();
    public UpdateLocationModel?   Location    { get; set; }
}