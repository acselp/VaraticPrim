using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Exceptions;
using VaraticPrim.Framework.Helpers;
using VaraticPrim.Framework.Mappers;
using VaraticPrim.Framework.Models.User;
using VaraticPrim.Framework.Validators;

namespace VaraticPrim.Framework.Managers;

[AllowAnonymous]
public class UserManager
{
    private readonly UserCreateModelValidator _createModelValidator;
    private readonly HashHelper               _hashHelper;
    private readonly ILogger<UserManager>     _logger;
    private readonly UserMapper               _userMapper;
    private readonly IUserRepository          _userRepository;

    public UserManager(IUserRepository          userRepository,       UserMapper userMapper, HashHelper hashHelper,
                       UserCreateModelValidator createModelValidator, ILogger<UserManager> logger)
    {
        _userRepository       = userRepository;
        _userMapper           = userMapper;
        _hashHelper           = hashHelper;
        _createModelValidator = createModelValidator;
        _logger               = logger;
    }

    public async Task<IEnumerable<UserModel>> GetAll()
    {
        return (await _userRepository.GetAll()).Select(_userMapper.ToModel);
    }

    public async Task<UserModel> Create(CreateUserModel model)
    {
        try
        {
            _logger.LogInformation("Creating user...");
            await _createModelValidator.ValidateAndThrowAsync(model);

            if (await _userRepository.UserWithEmailExists(model.Email))
            {
                _logger.LogWarning($"User with email = {model.Email} already exists");
                throw new UserAlreadyExistsException($"User with email = {model.Email} already exists");
            }

            var passwordSalt = _hashHelper.GenerateSalt();
            var userEntity   = _userMapper.ToEntity(model);

            userEntity.PasswordSalt = passwordSalt;
            userEntity.PasswordHash = _hashHelper.Hash(model.Password, passwordSalt);

            await _userRepository.Insert(userEntity);
            var userModel = _userMapper.ToModel(userEntity);
            _logger.LogInformation("User created.");

            return userModel;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create user");
            throw;
        }
    }
}