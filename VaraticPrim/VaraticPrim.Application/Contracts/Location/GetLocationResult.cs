using VaraticPrim.Application.Contracts.Address;
using VaraticPrim.Application.Contracts.Counter;

namespace VaraticPrim.Application.Contracts.Location;

public class GetLocationResult
{
    public         int                           Id          { get; set; }
    public         int                           CustomerId  { get; set; }
    public virtual GetAddressResult?             Address     { get; set; }
    public virtual IEnumerable<GetCounterResult> CounterList { get; set; } = new List<GetCounterResult>();
}