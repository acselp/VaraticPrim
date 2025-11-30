using VaraticPrim.Application.Contracts.ContactInfo;
using VaraticPrim.Application.Contracts.Location;

namespace VaraticPrim.Application.Contracts.Customer;

public class GetCustomerResult
{
    public int                  Id          { get; set; }
    public int                  AccountNr   { get; set; }
    public GetContactInfoResult ContactInfo { get; set; } = new();
    public GetLocationResult?   Location    { get; set; } = new();
}