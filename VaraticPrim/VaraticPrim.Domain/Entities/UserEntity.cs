using System.ComponentModel.DataAnnotations.Schema;

namespace VaraticPrim.Domain.Entities;

[Table("user")]
public class UserEntity : BaseEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
}