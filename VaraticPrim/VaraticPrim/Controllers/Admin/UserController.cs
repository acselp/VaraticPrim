using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaraticPrim.Framework.Managers;
using VaraticPrim.Framework.Models.User;
using ValidationException = FluentValidation.ValidationException;

namespace VaraticPrim.Api.Controllers.Admin;

public class UserController : BaseAdminController
{
    private readonly UserManager _userManager;

    public UserController(UserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userManager.GetAll());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] CreateUserModel model)
    {
        try
        {
            return Ok(await _userManager.Create(model));
        }
        catch (ValidationException e)
        {
            return ValidationError(e);
        }
    }
}