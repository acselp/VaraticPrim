using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaraticPrim.Api.Controllers.Shared;
using VaraticPrim.Framework.Models.Auth;

namespace VaraticPrim.Api.Controllers.Auth;

public class AuthenticationController : ApiBaseController
{
    private readonly Framework.Managers.AuthenticationManager _authenticationManager;

    public AuthenticationController(Framework.Managers.AuthenticationManager authenticationManager)
    {
        _authenticationManager = authenticationManager;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        var model = await _authenticationManager.Login(loginModel);
        return Ok(model);
    }

    // [AllowAnonymous]
    // [HttpPost("refresh-token")]
    // public async Task<IActionResult> LoginByRefreshToken([FromBody] LoginByRefreshTokenModel tokenModel)
    // {
    //     var model = await _authenticationManager.LoginByRefreshToken(tokenModel.RefreshToken);
    //     return Ok(model);
    // }
}