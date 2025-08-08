using VaraticPrim.Framework.Models.Address;
using VaraticPrim.Framework.Models.Counter;
using VaraticPrim.Framework.Models.Customer;
using VaraticPrim.Framework.Models.Shared;

namespace VaraticPrim.Framework.Models.Location;

public class LocationModel : BaseReadModel
{
    public AddressModel              Address     { get; set; }
    public CustomerModel             Customer    { get; set; }
    public IEnumerable<CounterModel> CounterList { get; set; } = new List<CounterModel>();
}