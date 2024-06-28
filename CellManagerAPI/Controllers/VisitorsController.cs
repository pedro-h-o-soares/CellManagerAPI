using Microsoft.AspNetCore.Mvc;
using CellManagerAPI.Application.Interfaces;
using CellManagerAPI.Application.DTO.DTO;

namespace VisitorManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitorsController : ControllerBase
{
    private readonly IApplicationServiceVisitors _service;
    public VisitorsController(IApplicationServiceVisitors service)
    {
        _service = service;
    }

    /// <summary>
    /// You can search for Visitors here.
    /// </summary>
    /// <param name="skip">Number of visitors to skip</param>
    /// <param name="take">Number of visitors to take</param>
    /// <returns>This endpoint returns a list of Visitors</returns>
    [HttpGet]
    public IActionResult Get(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 10)
    {
        return Ok(_service.GetAll(skip, take));
    }

    /// <summary>
    /// You can search for a specific Visitor here.
    /// </summary>
    /// <param name="id">The id of the Visitor you are looking for</param>
    /// <returns>This endpoint returns the Visitor with the given id</returns>
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _service.GetById(id);
        if (result is null) return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// You can create Visitors here.
    /// </summary>
    /// <param name="dto">Object of Visitor to be created</param>
    /// <returns>This endpoint returns the created Visitor</returns>
    [HttpPost]
    public IActionResult Create(CreateVisitorsDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);
            var visitor = _service.Add(dto);

            return CreatedAtAction(nameof(Get), new { id = visitor.Id }, visitor);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
