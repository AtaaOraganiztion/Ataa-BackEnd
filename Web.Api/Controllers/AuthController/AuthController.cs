using Application.Abstractions;
using Application.Features.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Authentication.Dtos;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var result = await _authService.LoginAsync(request);
        return result == null ? Unauthorized(new { message = "Invalid credentials" }) : Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] LoginRequestDto request)
    {
        var result = await _authService.RegisterAsync(request);
        return result == null ? BadRequest(new { message = "Email exists" }) : Ok(result);
    }
}
