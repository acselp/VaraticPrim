using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaraticPrim.Api.Controllers.Shared;
using VaraticPrim.Domain.Exceptions;
using VaraticPrim.Framework.Errors.FrontEndErrors;
using VaraticPrim.Framework.Managers;
using VaraticPrim.Framework.Models.Auth;
using VaraticPrim.Framework.Models.Token;

namespace VaraticPrim.Api.Controllers.Auth;

[AllowAnonymous]
[Route("/auth")]
public class AuthenticationController : ApiBaseController
{
    private readonly AuthenticationManager _authenticationManager;

    public AuthenticationController(AuthenticationManager authenticationManager)
    {
        _authenticationManager = authenticationManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        try
        {
            var model = await _authenticationManager.Login(loginModel);
            return Ok(model);
        }
        catch (WrongPasswordOrEmailException e)
        {
            return BadRequest(FrontEndErrors.WrongPasswordOrEmailError);
        }
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> LoginByRefreshToken([FromBody] LoginByRefreshTokenModel tokenModel)
    {
        try
        {
            var model = await _authenticationManager.LoginByRefreshToken(tokenModel.RefreshToken);
            return Ok(model);
        }
        catch (InvalidAccessTokenOrRefreshTokenException e)
        {
            return BadRequest(FrontEndErrors.InvalidRefreshTokenOrAccessTokenError);
        }
    }
}