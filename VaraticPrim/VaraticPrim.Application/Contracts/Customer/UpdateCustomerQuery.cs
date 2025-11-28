using VaraticPrim.Application.Contracts.ContactInfo;
using VaraticPrim.Application.Contracts.Location;

namespace VaraticPrim.Application.Contracts.Customer;

public class UpdateCustomerQuery
{
    public int                    Id          { get; set; }
    public int                    AccountNr   { get; set; }
    public UpdateContactInfoQuery ContactInfo { get; set; } = new();
    public UpdateLocationQuery?   Location    { get; set; } = new();
}