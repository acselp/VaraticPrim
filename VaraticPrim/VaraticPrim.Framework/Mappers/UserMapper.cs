using VaraticPrim.Domain.Entities;
using VaraticPrim.Framework.Models.User;

namespace VaraticPrim.Framework.Mappers;

public class UserMapper
{
    public UserModel ToModel(UserEntity entity)
    {
        return new UserModel
        {
            Email = entity.Email
        };
    }
    
    public UserEntity ToEntity(CreateUserModel model)
    {
        return new UserEntity
        {
            Email = model.Email,
            PasswordHash = model.Password
        };
    }
}