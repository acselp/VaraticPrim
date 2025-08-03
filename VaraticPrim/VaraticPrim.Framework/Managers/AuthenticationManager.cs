using Microsoft.Extensions.Logging;
using VaraticPrim.Application.Repository;
using VaraticPrim.Framework.Helpers;
using VaraticPrim.Framework.Models.Auth;

namespace VaraticPrim.Framework.Managers;

public class AuthenticationManager
{
    private readonly TokenGeneratorHelper           _tokenGeneratorHelper;
    private readonly IUserRepository                _userRepository;
    private readonly ILogger<AuthenticationManager> _logger;
    private readonly HashHelper                     _hashHelper;


    public AuthenticationManager(
        TokenGeneratorHelper           tokenGeneratorHelper,
        IUserRepository                userRepository,
        ILogger<AuthenticationManager> logger,
        HashHelper                     hashHelper)
    {
        _hashHelper           = hashHelper;
        _tokenGeneratorHelper = tokenGeneratorHelper;
        _userRepository       = userRepository;
        _logger               = logger;
    }

    public async Task<LoginResultModel> Login(LoginModel loginModel)
    {
        try
        {
            // _logger.LogInformation("Start authenticating user");
            // var currentUser = await _userRepository.GetByEmail(loginModel.Email);
            //
            // if (currentUser == null || !_hashHelper.PasswordHashMatches(currentUser.PasswordHash,
            //                                                             loginModel.Password, currentUser.PasswordSalt))
            // {
            //     _logger.LogWarning("Wrong email or password");
            //     throw new Exception("Wrong email or password");
            // }

            var accessToken  = _tokenGeneratorHelper.GenerateAccessToken(123);
            var refreshToken = _tokenGeneratorHelper.GenerateRefreshToken();

            // await _refreshRepository.Insert(
            //     new RefreshTokenEntity
            //     {
            //         RefreshToken   = refreshToken.Token,
            //         UserId         = currentUser.Id,
            //         ExpirationTime = refreshToken.Expires
            //     });

            return new LoginResultModel
                   {
                       AccessToken                = accessToken.AccessToken,
                       ExpiresIn                  = accessToken.ExpirationTime,
                       TokenType                  = accessToken.TokenType,
                       RefreshToken               = refreshToken.Token,
                       RefreshTokenExpirationTime = refreshToken.Expires
                   };
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to login");
            throw;
        }
    }

    // public async Task<LoginResultModel> LoginByRefreshToken(string token)
    // {
    //     var currentUser  = await GetUserByRefreshToken(token);
    //     var accessToken  = _tokenGeneratorHelper.GenerateAccessToken(currentUser.Id);
    //     var refreshToken = _tokenGeneratorHelper.GenerateRefreshToken();
    //      
    //     await _refreshRepository.Insert(
    //         new RefreshTokenEntity
    //         {
    //             RefreshToken   = refreshToken.Token,
    //             UserId         = currentUser.Id,
    //             ExpirationTime = refreshToken.Expires
    //         });
    //
    //     return new LoginResultModel
    //     {
    //         AccessToken                = accessToken.AccessToken,
    //         ExpiresIn                  = accessToken.ExpirationTime,
    //         TokenType                  = accessToken.TokenType,
    //         RefreshToken               = refreshToken.Token,
    //         RefreshTokenExpirationTime = refreshToken.Expires
    //     };
    // }
    //
    // private async Task<UserEntity> GetUserByRefreshToken(string token)
    // {
    //     var entity = await _refreshRepository.GetUserByToken(token);
    //
    //     if (entity == null || entity.IsExpired)
    //     {
    //         throw new InvalidAccessTokenOrRefreshTokenException();
    //     }
    //
    //     return entity.UserEntity ?? throw new InvalidAccessTokenOrRefreshTokenException();
    // }
}