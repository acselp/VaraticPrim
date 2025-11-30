using VaraticPrim.Domain.Paged;

namespace VaraticPrim.Application.Filters;

public class CustomerFilter : PagedFilter
{
    public bool Deleted { get; set; }
}