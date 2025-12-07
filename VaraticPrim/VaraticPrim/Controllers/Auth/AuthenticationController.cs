using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaraticPrim.Api.Controllers.Shared;
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
        catch (ValidationException e)
        {
            return ValidationError(e);
        }
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> LoginByRefreshToken([FromBody] LoginByRefreshTokenModel tokenModel)
    {
        var model = await _authenticationManager.LoginByRefreshToken(tokenModel.RefreshToken);
        return Ok(model);
    }
}