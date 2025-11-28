using VaraticPrim.Application.Contracts.ContactInfo;
using VaraticPrim.Application.Contracts.Location;

namespace VaraticPrim.Application.Contracts.Customer;

public class UpdateCustomerResult
{
    public int                     Id          { get; set; }
    public int                     AccountNr   { get; set; }
    public UpdateContactInfoResult ContactInfo { get; set; } = new();
    public UpdateLocationResult?   Location    { get; set; } = new();
}