using Microsoft.AspNetCore.Mvc;
using VaraticPrim.Domain.Exceptions;
using VaraticPrim.Framework.Errors.FrontEndErrors;
using VaraticPrim.Framework.Managers;
using VaraticPrim.Framework.Models.User;
using ValidationException = FluentValidation.ValidationException;

namespace VaraticPrim.Api.Controllers.Web;

public class UserController : BaseClientController
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
        catch (UserAlreadyExistsException e)
        {
            return BadRequest(FrontEndErrors.UserAlreadyExists.ErrorCode,
                              FrontEndErrors.UserAlreadyExists.ErrorMessage);
        }
    }
}