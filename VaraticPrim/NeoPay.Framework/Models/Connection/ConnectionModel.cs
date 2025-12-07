using NeoPay.Framework.Models.Shared;

namespace NeoPay.Framework.Models.Connection;

public class ConnectionModel : BaseModel
{
    public int Status     { get; set; }
    public int CustomerId { get; set; }
    public int UtilityId  { get; set; }
}
