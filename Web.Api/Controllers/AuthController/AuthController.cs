using Application.Abstractions;
using Application.Abstractions.Authentication;
using BCrypt.Net;
using Domain.Models; // LoginModel
using Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


[ApiController]
[Route("api/V1[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly ITokenService _tokenService;

    public AuthController(ApplicationDbContext db, ITokenService tokenService)
    {
        _db = db;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == model.Username);
        if (user == null) return Unauthorized("Invalid credentials");

        // Verify password (bcrypt)
        if (!BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            return Unauthorized("Invalid credentials");

        var token = _tokenService.GenerateToken(user.Id.ToString(), user.Email,user.UserName);
        return Ok(new { token });
    }
}
