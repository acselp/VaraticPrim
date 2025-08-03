using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VaraticPrim.Framework.Models.Token;
using VaraticPrim.JwtAuth;

namespace VaraticPrim.Framework.Helpers;

public class TokenGeneratorHelper
{
    private readonly IOptions<JwtOptions> _options;

    public TokenGeneratorHelper(IOptions<JwtOptions> options)
    {
        _options = options;
    }
    
    public AccessTokenModel GenerateAccessToken(int userId)
    {
        var securityKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Key));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(Constants.ClaimTypes.UserId, userId.ToString())
        };

        var expirationTime = DateTime.UtcNow.AddMinutes(_options.Value.AccessTokenExpirationTimeMin);
        var token = new JwtSecurityToken(
            _options.Value.Issuer,
            _options.Value.Audience,
            claims,
            expires: expirationTime,
            signingCredentials: credentials);

        return new AccessTokenModel
        {
            ExpirationTime = expirationTime,
            AccessToken    = new JwtSecurityTokenHandler().WriteToken(token),
            TokenType      = "Bearer"
        };
    }
    
    public RefreshTokenModel GenerateRefreshToken()
    {
        var       randomNumber = new byte[64];
        using var rng          = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);

        return new RefreshTokenModel
        {
            Token   = Convert.ToBase64String(randomNumber),
            Expires = DateTime.UtcNow.AddMinutes(_options.Value.RefreshTokenExpirationTimeMin),
        };
    }
}