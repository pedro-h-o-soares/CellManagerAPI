using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.Interfaces;
using CellManagerAPI.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
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

    /// <summary>
    /// You can search for Cells here.
    /// </summary>
    /// <param name="skip">Number of cells to skip</param>
    /// <param name="take">Number of cells to take</param>
    /// <returns>This endpoint returns a list of Cells</returns>
    [HttpGet]
    public IActionResult Get(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 10)
    {
        return Ok(_service.GetAll(skip, take));
    }

    /// <summary>
    /// You can search for a specific Cell here.
    /// </summary>
    /// <param name="id">The id of the Cell you are looking for</param>
    /// <returns>This endpoint returns the Cell with the given id</returns>
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _service.GetById(id);
        if (result is null) return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// You can create Cells here.
    /// </summary>
    /// <param name="dto">Object of Cell to be created</param>
    /// <returns>This endpoint returns the created Cell</returns>
    [HttpPost]
    public IActionResult Create(CreateCellsDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);
            var cell = _service.Add(dto);

            return CreatedAtAction(nameof(GetById), new { id = cell.Id }, cell);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// You can update Cells here.
    /// </summary>
    /// <param name="id">Id of Cell to be updated</param>
    /// <param name="dto">Object of Cell to be updated</param>
    /// <returns>This endpoint returns the updated Cell</returns>
    [HttpPut("{id}")]
    public IActionResult Update(
        int id,
        [FromBody] CreateCellsDto dto)
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
    /// You can partially update Cells here
    /// </summary>
    /// <param name="id">Id of Cell to be updated</param>
    /// <param name="patch">JsonPatch object of Cell to be updated</param>
    /// <returns>This endpoint returns no content</returns>
    [HttpPatch("{id}")]
    public IActionResult Patch(
        int id,
        [FromBody] JsonPatchDocument<CreateCellsDto> patch)
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
