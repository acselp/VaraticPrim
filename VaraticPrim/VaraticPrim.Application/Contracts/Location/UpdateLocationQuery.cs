using VaraticPrim.Application.Contracts.Address;
using VaraticPrim.Application.Contracts.Counter;

namespace VaraticPrim.Application.Contracts.Location;

public class UpdateLocationQuery
{
    public         int                             CustomerId  { get; set; }
    public virtual UpdateAddressQuery?             Address     { get; set; }
    public virtual IEnumerable<UpdateCounterQuery> CounterList { get; set; } = new List<UpdateCounterQuery>();
}