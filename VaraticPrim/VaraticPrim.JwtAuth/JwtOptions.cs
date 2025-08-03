namespace VaraticPrim.JwtAuth;

public class JwtOptions
{
    public static string SectionName { get; set; } = "Jwt";
    
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int AccessTokenExpirationTimeMin { get; set; }
    public int RefreshTokenExpirationTimeMin { get; set; }
}