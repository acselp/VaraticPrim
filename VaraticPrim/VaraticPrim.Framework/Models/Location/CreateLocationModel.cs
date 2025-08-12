using VaraticPrim.Framework.Models.Address;

namespace VaraticPrim.Framework.Models.Location;

public class CreateLocationModel
{
    public int CustomerId { get; set; }
    public CreateAddressModel? Address { get; set; }
}