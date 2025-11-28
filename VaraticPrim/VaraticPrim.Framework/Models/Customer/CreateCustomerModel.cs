using VaraticPrim.Framework.Models.ContactInfo;

namespace VaraticPrim.Framework.Models.Customer;

public class CreateCustomerModel
{
    public int                    AccountNr   { get; set; }
    public CreateContactInfoModel ContactInfo { get; set; } = new();
}