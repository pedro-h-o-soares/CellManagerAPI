﻿using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CellManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IApplicationServiceEvents _service;
    public EventsController(IApplicationServiceEvents service)
    {
        _service = service;
    }

    /// <summary>
    /// You can search for Events here.
    /// </summary>
    /// <param name="skip">Number of members to skip</param>
    /// <param name="take">Number of members to take</param>
    /// <returns>This endpoint returns a list of Events</returns>
    [HttpGet]
    public IActionResult Get(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return Ok(_service.GetAll(skip, take));
    }

    // <summary>
    /// You can search for a specific Event here.
    /// </summary>
    /// <param name="id">The id of the Event you are looking for</param>
    /// <returns>This endpoint returns the Event with the given id</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var result = _service.GetById(id);
        if (result is null) return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// You can create Events here
    /// </summary>
    /// <param name="dto">Object of Event to be created</param>
    /// <returns>This endpoint returns the created Event</returns>
    [HttpPost]
    public IActionResult Create(CreateEventsDto dto)
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
    /// You can update Events here.
    /// </summary>
    /// <param name="id">Id of Event to be updated</param>
    /// <param name="dto">Object of Event to be updated</param>
    /// <returns>This endpoint returns no content</returns>
    [HttpPut("{id}")]
    public IActionResult Update(
        int id,
        [FromBody] CreateEventsDto dto)
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
    /// You can partially update Events here
    /// </summary>
    /// <param name="id">Id of Event to be updated</param>
    /// <param name="patch">JsonPatch object of Event to be updated</param>
    /// <returns>This endpoint returns no content</returns>
    [HttpPatch("{id}")]
    public IActionResult Patch(
        int id,
        [FromBody] JsonPatchDocument<CreateEventsDto> patch)
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

    /// <summary>
    /// You can update the list of present members here
    /// </summary>
    /// <param name="id">Id of Event to be updated</param>
    /// <param name="membersId">Id list of present members</param>
    /// <returns></returns>
    [HttpPut("{id}/members")]
    public IActionResult PutMembers(
        int id,
        [FromBody] IEnumerable<int> membersId)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(membersId);
            _service.UpdateMembers(id, membersId);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// You can update the list of present visitors here
    /// </summary>
    /// <param name="id">Id of Event to be updated</param>
    /// <param name="visitorsId">Id list of present visitors</param>
    /// <returns></returns>
    [HttpPut("{id}/visitors")]
    public IActionResult PutVisitors(
        int id,
        [FromBody] IEnumerable<int> visitorsId)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(visitorsId);
            _service.UpdateVisitors(id, visitorsId);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
