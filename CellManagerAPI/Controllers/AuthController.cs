using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.DTO.DTO.Auth;
using CellManagerAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CellManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IApplicationServiceAuth _service;

    public AuthController(IApplicationServiceAuth service)
    {
        _service = service;
    }

    /// <summary>
    /// You can sign in here
    /// </summary>
    /// <param name="userInfo">User credentials for login</param>
    /// <returns>Object with JWT token and user data</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserInfoDto userInfo)
    {
        try
        {
            var token = await _service.Login(userInfo);

            return Ok(token);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUsersDto user)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(user);
            
            await _service.Register(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

        return Ok();
    }
}
