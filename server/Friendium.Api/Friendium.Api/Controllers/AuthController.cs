using System.Security.Claims;
using Friendium.Api.DTOs;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendium.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class AuthController(IAuthService service, IUserRepository repo) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            var existingUser = await service.RegisterAsync(dto);
            var responseDto = new UserDto(existingUser.Id.ToString(), existingUser.Name, existingUser.Email);
            return Ok(responseDto);
        }
        catch (InvalidOperationException e)
        {
            return Conflict(new { message = e.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = await service.ValidateCredentialsAsync(dto);
        if (user == null) return Unauthorized();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        
        return Ok(new UserDto(user.Id.ToString(), user.Name, user.Email));
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return NoContent();
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetMe()
    {
        var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(idClaim, out var id)) return Unauthorized();

        var user = await repo.GetByIdAsync(id);
        if (user == null) return NotFound();
        
        return Ok(new UserDto(user.Id.ToString(), user.Name, user.Email));
    }
    
}