using VaraticPrim.Application.Contracts.ContactInfo;

namespace VaraticPrim.Application.Contracts.Customer;

public class CreateCustomerResult
{
    public         int                     Id          { get; set; }
    public         int                     AccountNr   { get; set; }
    public virtual CreateContactInfoResult ContactInfo { get; set; } = new();
}