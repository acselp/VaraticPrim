using VaraticPrim.Application.Contracts.Address;
using VaraticPrim.Application.Contracts.Counter;

namespace VaraticPrim.Application.Contracts.Location;

public class CreateLocationQuery
{
    public         int                             CustomerId  { get; set; }
    public virtual CreateAddressQuery?             Address     { get; set; }
    public virtual IEnumerable<CreateCounterQuery> CounterList { get; set; } = new List<CreateCounterQuery>();
}