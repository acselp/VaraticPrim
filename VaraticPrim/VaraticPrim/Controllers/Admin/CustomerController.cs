using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaraticPrim.Domain.Exceptions;
using VaraticPrim.Framework.Errors.FrontEndErrors;
using VaraticPrim.Framework.Managers;
using VaraticPrim.Framework.Models.Customer;

namespace VaraticPrim.Api.Controllers.Admin;

public class CustomerController : BaseAdminController
{
    private readonly CustomerManager _customerManager;

    public CustomerController(CustomerManager customerManager)
    {
        _customerManager = customerManager;
    }

    [AllowAnonymous]
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateCustomerModel model)
    {
        try
        {
            return Ok(await _customerManager.Create(model));
        }
        catch (ValidationException e)
        {
            return ValidationError(e);
        }
        catch (CustomerAccountNumberAlreadyExists)
        {
            return BadRequest(FrontEndErrors.CustomerAccountNrAlreadyExists);
        }
    }
    //
    // [AllowAnonymous]
    // [HttpPost("gridGetAll")]
    // public async Task<IActionResult> GridGetAll()
    // {
    //     return Ok(await _customerManager.GridGetAll());
    // }
}