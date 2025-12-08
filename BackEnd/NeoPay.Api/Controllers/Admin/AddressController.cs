using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NeoPay.Domain.Exceptions;
using NeoPay.Framework.Errors.FrontEndErrors;
using NeoPay.Framework.Managers;
using NeoPay.Framework.Models.Address;

namespace NeoPay.Api.Controllers.Admin;

[Route("address")]
public class AddressController : BaseAdminController
{
    private readonly AddressManager _addressManager;

    public AddressController(AddressManager addressManager)
    {
        _addressManager = addressManager;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAddressModel address)
    {
        try
        {
            await _addressManager.Create(address);
            return Ok();
        }
        catch (ValidationException ex)
        {
            return ValidationError(ex);
        }
        catch (NotFoundException)
        {
            return NotFound(FrontEndErrors.AddressCouldNotBeFound);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAddressModel address)
    {
        try
        {
            await _addressManager.Update(address);
            return Ok();
        }
        catch (ValidationException ex)
        {
            return ValidationError(ex);
        }
        catch (NotFoundException)
        {
            return NotFound(FrontEndErrors.AddressCouldNotBeFound);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _addressManager.Delete(id);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound(FrontEndErrors.AddressCouldNotBeFound);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAddressFilterModel filter)
    {
        try
        {
            var result = await _addressManager.GetAll(filter);
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest(FrontEndErrors.ErrorLoadingAddresses);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _addressManager.GetById(id);
            return Ok(result);
        }
        catch (NotFoundException)
        {
            return NotFound(FrontEndErrors.AddressCouldNotBeFound);
        }
    }
}
