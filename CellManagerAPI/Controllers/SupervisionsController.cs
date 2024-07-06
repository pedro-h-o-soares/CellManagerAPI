using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CellManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SupervisionsController : ControllerBase
{
    private readonly IApplicationServiceSupervisions _service;

    public SupervisionsController(IApplicationServiceSupervisions service)
    {
        _service = service;
    }

    /// <summary>
    /// You can search for Supervisions here.
    /// </summary>
    /// <param name="skip">Number of Supervisions to skip</param>
    /// <param name="take">Number of Supervisions to take</param>
    /// <returns>This endpoint returns a list of Supervisions</returns>
    [HttpGet]
    public IActionResult Get(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 10)
    {
        return Ok(_service.GetAll(skip, take));
    }

    /// <summary>
    /// You can search for a specific Supervision here.
    /// </summary>
    /// <param name="id">The id of the Supervision you are looking for</param>
    /// <returns>This endpoint returns the Supervision with the given id</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var result = _service.GetById(id);
        if (result is null) return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// You can create Supervisions here.
    /// </summary>
    /// <param name="dto">Object of Supervision to be created</param>
    /// <returns>This endpoint returns the created Supervision</returns>
    [HttpPost]
    public IActionResult Create(CreateSupervisionsDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);
            var supervision = _service.Add(dto);

            return CreatedAtAction(nameof(Get), new { id = supervision.Id }, supervision);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// You can update Supervisions here.
    /// </summary>
    /// <param name="id">Id of Supervision to be updated</param>
    /// <param name="dto">Object of Supervision to be updated</param>
    /// <returns>This endpoint returns the updated Supervision</returns>
    [HttpPut("{id}")]
    public IActionResult Update(
        int id, 
        [FromBody] CreateSupervisionsDto dto)
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

    /// <summary>
    /// You can partially update Supervisions here
    /// </summary>
    /// <param name="id">Id of Supervision to be updated</param>
    /// <param name="patch">JsonPatch object of Supervision to be updated</param>
    /// <returns>This endpoint returns no content</returns>
    [HttpPatch("{id}")]
    public IActionResult Patch(
        int id,
        [FromBody] JsonPatchDocument<CreateSupervisionsDto> patch)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(patch);
            _service.Patch(id, patch);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
