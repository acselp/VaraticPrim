using VaraticPrim.Application.Contracts.Address;
using VaraticPrim.Application.Contracts.Counter;

namespace VaraticPrim.Application.Contracts.Location;

public class UpdateLocationResult
{
    public         int                              Id          { get; set; }
    public         int                              CustomerId  { get; set; }
    public virtual UpdateAddressResult?             Address     { get; set; }
    public virtual IEnumerable<UpdateCounterResult> CounterList { get; set; } = new List<UpdateCounterResult>();
}