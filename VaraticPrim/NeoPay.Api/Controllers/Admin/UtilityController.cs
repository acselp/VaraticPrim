using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NeoPay.Domain.Exceptions;
using NeoPay.Framework.Managers;
using NeoPay.Framework.Models.Utility;

namespace NeoPay.Api.Controllers.Admin;

[Route("utility")]
public class UtilityController : BaseAdminController
{
    private readonly UtilityManager _utilityManager;

    public UtilityController(UtilityManager utilityManager)
    {
        _utilityManager = utilityManager;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUtilityModel utility)
    {
        try
        {
            await _utilityManager.Create(utility);
            return Ok();
        }
        catch (ValidationException ex)
        {
            return ValidationError(ex);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateUtilityModel utility)
    {
        try
        {
            await _utilityManager.Update(utility);
            return Ok();
        }
        catch (ValidationException ex)
        {
            return ValidationError(ex);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _utilityManager.Delete(id);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetUtilityFilterModel filter)
    {
        try
        {
            var result = await _utilityManager.GetAll(filter);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _utilityManager.GetById(id);
            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
