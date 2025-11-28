using VaraticPrim.Framework.Models.ContactInfo;
using VaraticPrim.Framework.Models.Location;
using VaraticPrim.Framework.Models.Shared;

namespace VaraticPrim.Framework.Models.Customer;

public class CustomerModel : BaseReadModel
{
    public int               Id          { get; set; }
    public int               AccountNr   { get; set; }
    public ContactInfoModel? ContactInfo { get; set; }
    public LocationModel?    Location    { get; set; }
}