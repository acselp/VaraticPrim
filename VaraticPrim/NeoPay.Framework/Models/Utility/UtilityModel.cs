using NeoPay.Domain.Enums;
using NeoPay.Framework.Models.Shared;

namespace NeoPay.Framework.Models.Utility;

public class UtilityModel : BaseModel
{
    public string Name     { get; set; } = null!;
    public UnitType    UnitType { get; set; }
}
