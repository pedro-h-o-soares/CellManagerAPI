using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.Interfaces;
using CellManagerAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CellManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CellsController : ControllerBase
{
    private readonly IApplicationServiceCells _service;

    public CellsController(IApplicationServiceCells service)
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
    public IActionResult Create(CreateCellsDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);
            var cell = _service.Add(dto);

            return CreatedAtAction(nameof(Get), new { cell.Id }, cell);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
