using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.Interfaces;
using CellManagerAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CellManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly IApplicationServiceMembers _service;
    public MembersController(IApplicationServiceMembers service)
    {
        _service = service;
    }

    /// <summary>
    /// You can search for Members here.
    /// </summary>
    /// <param name="skip">Number of members to skip</param>
    /// <param name="take">Number of members to take</param>
    /// <returns>This endpoint returns a list of Members</returns>
    [HttpGet]
    public IActionResult Get(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return Ok(_service.GetAll(skip, take));
    }

    // <summary>
    /// You can search for a specific Member here.
    /// </summary>
    /// <param name="id">The id of the Member you are looking for</param>
    /// <returns>This endpoint returns the Member with the given id</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var result = _service.GetById(id);
        if (result is null) return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// You can create Members here
    /// </summary>
    /// <param name="dto">Object of Member to be created</param>
    /// <returns>This endpoint returns the created Member</returns>
    [HttpPost]
    public IActionResult Create(CreateMembersDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);
            var member = _service.Add(dto);

            return CreatedAtAction(nameof(Get), new { id = member.Id }, member);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// You can update Members here.
    /// </summary>
    /// <param name="id">Id of Member to be updated</param>
    /// <param name="dto">Object of Member to be updated</param>
    /// <returns>This endpoint returns the updated Member</returns>
    [HttpPut("{id}")]
    public IActionResult Update(
        int id,
        [FromBody] CreateMembersDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);
            _service.Update(id, dto);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
