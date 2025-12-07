using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NeoPay.Domain.Exceptions;
using NeoPay.Framework.Errors.FrontEndErrors;
using NeoPay.Framework.Managers;
using NeoPay.Framework.Models.Connection;

namespace NeoPay.Api.Controllers.Admin;

[Route("connection")]
public class ConnectionController : BaseAdminController
{
    private readonly ConnectionManager _connectionManager;

    public ConnectionController(ConnectionManager connectionManager)
    {
        _connectionManager = connectionManager;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateConnectionModel connection)
    {
        try
        {
            await _connectionManager.Create(connection);
            return Ok();
        }
        catch (ValidationException ex)
        {
            return ValidationError(ex);
        }
        catch (NotFoundException)
        {
            return NotFound(FrontEndErrors.ConnectionCouldNotBeFound);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateConnectionModel connection)
    {
        try
        {
            await _connectionManager.Update(connection);
            return Ok();
        }
        catch (ValidationException ex)
        {
            return ValidationError(ex);
        }
        catch (NotFoundException)
        {
            return NotFound(FrontEndErrors.ConnectionCouldNotBeFound);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _connectionManager.Delete(id);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound(FrontEndErrors.ConnectionCouldNotBeFound);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetConnectionFilterModel filter)
    {
        try
        {
            var result = await _connectionManager.GetAll(filter);
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest(FrontEndErrors.ErrorLoadingConnections);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _connectionManager.GetById(id);
            return Ok(result);
        }
        catch (NotFoundException)
        {
            return NotFound(FrontEndErrors.ConnectionCouldNotBeFound);
        }
    }
}
