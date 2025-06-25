using Microsoft.AspNetCore.Mvc;
using SmartHomeAPI.Business.Dtos.AppUserDtos;
using SmartHomeAPI.Business.Services.Abstractions;

namespace SmartHomeAPI.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        var result = await _authService.RegisterAsync(model);
        if (!result.succes)
            return BadRequest(result.message);

        return Ok(result.message);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        var (success, message, token) = await _authService.LoginAsync(model);

        if (success)
        {
            return Ok(new { Success = true, Message = message, Token = token });
        }

        return Unauthorized(new { Success = false, Message = message });
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _authService.GetAllUserAsync();
        return Ok(users);
    }
}
