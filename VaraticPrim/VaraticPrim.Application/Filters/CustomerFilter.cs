using VaraticPrim.Domain.Paged;

namespace VaraticPrim.Framework.Filters;

public class CustomerFilter : PagedFilter
{
    public bool Deleted { get; set; }
}