namespace VaraticPrim.Framework.Models.Token;

public class RefreshTokenModel
{
    public string   Token   { get; set; }
    public DateTime Expires { get; set; }
}