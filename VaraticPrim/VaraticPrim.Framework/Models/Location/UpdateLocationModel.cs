using VaraticPrim.Framework.Models.Address;
using VaraticPrim.Framework.Models.Counter;

namespace VaraticPrim.Framework.Models.Location;

public class UpdateLocationModel
{
    public int                             Id          { get; set; }
    public int                             CustomerId  { get; set; }
    public UpdateAddressModel?             Address     { get; set; }
    public IEnumerable<UpdateCounterModel> CounterList { get; set; } = new List<UpdateCounterModel>();
}