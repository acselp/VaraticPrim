namespace NeoPay.Domain.Paged;

public class PagedFilter
{
    public int PageIndex { get; set; } = 0;
    public int PageSize  { get; set; } = int.MaxValue;
}