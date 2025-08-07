using System.ComponentModel.DataAnnotations.Schema;

namespace VaraticPrim.Domain.Entities;

[Table("refresh_token")]
public class RefreshTokenEntity : BaseEntity
{
    public         string     RefreshToken   { get; set; }
    public         int        UserId         { get; set; }
    public virtual UserEntity User           { get; set; }
    public         DateTime   ExpirationTime { get; set; }
    public         bool       IsExpired      => ExpirationTime < DateTime.UtcNow;
}