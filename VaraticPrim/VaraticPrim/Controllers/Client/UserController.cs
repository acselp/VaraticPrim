using Microsoft.AspNetCore.Mvc;
using VaraticPrim.Framework.Managers;
using VaraticPrim.Framework.Models.User;

namespace VaraticPrim.Api.Controllers.Client;

[Route("[controller]")]
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
        await _userManager.Create(model);
        
        return Ok();
    }
}