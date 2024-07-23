using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.Interfaces;
using CellManagerAPI.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CellManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IApplicationServiceUsers _service;

    public UsersController(IApplicationServiceUsers service)
    {
        _service = service;
    }

    /// <summary>
    /// You can search for Users here.
    /// </summary>
    /// <param name="skip">Number of users to skip</param>
    /// <param name="take">Number of users to take</param>
    /// <returns>This endpoint returns a list of Users</returns>
    [HttpGet]
    public IActionResult Get(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 10)
    {
        return Ok(_service.GetAll(skip, take));
    }

    /// <summary>
    /// You can search for a specific User here.
    /// </summary>
    /// <param name="id">The id of the User you are looking for</param>
    /// <returns>This endpoint returns the User with the given id</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _service.GetById(id);
        if (result is null) return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// You can update Users here.
    /// </summary>
    /// <param name="id">Id of User to be updated</param>
    /// <param name="dto">Object of User to be updated</param>
    /// <returns>This endpoint returns the updated User</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        string id,
        [FromBody] UpdateUsersDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);
            await _service.Update(id, dto);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// You can partially update Users here
    /// </summary>
    /// <param name="id">Id of User to be updated</param>
    /// <param name="patch">JsonPatch object of User to be updated</param>
    /// <returns>This endpoint returns no content</returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(
        string id,
        [FromBody] JsonPatchDocument<UpdateUsersDto> patch)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(patch);
            await _service.Patch(id, patch);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
