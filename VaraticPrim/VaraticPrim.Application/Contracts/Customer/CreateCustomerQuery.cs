using VaraticPrim.Application.Contracts.ContactInfo;

namespace VaraticPrim.Application.Contracts.Customer;

public class CreateCustomerQuery
{
    public         int                    AccountNr   { get; set; }
    public virtual CreateContactInfoQuery ContactInfo { get; set; } = new();
}