using VaraticPrim.Api.Models.User;
using VaraticPrim.Application.Repository;
using VaraticPrim.Framework.Mappers;
using VaraticPrim.Framework.Models.User;

namespace VaraticPrim.Framework.Managers;

public class UserManager
{
    private readonly IUserRepository _userRepository;
    private readonly UserMapper _userMapper;
    
    public UserManager(IUserRepository userRepository, UserMapper userMapper)
    {
        _userRepository = userRepository;
        _userMapper = userMapper;
    }

    public async Task<IEnumerable<UserModel>> GetAll()
    {
        return (await _userRepository.GetAll()).Select(_userMapper.ToModel);
    }
    
    public async Task Create(CreateUserModel model)
    {
        await _userRepository.Insert(_userMapper.ToEntity(model));
    }
}