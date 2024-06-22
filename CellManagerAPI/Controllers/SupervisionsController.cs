using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.Interfaces;
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

    [HttpGet]
    public IActionResult Get(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 10)
    {
        return Ok(_service.GetAll(skip, take));
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var result = _service.GetById(id);
        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create(CreateSupervisionsDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);
            var supervision = _service.Add(dto);

            return CreatedAtAction(nameof(Get), new { supervision.Id }, supervision);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
