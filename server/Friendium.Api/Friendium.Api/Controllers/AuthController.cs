using System.Security.Claims;
using Friendium.Api.DTOs.Request;
using Friendium.Api.Exceptions;
using Friendium.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendium.Api.Controllers;

/// <summary>
/// Controller responsible for handling authentication-related endpoints:
/// Registration, login, logout, and retrieving the currently authenticated user.
/// </summary>
[Route("api/auth")]
[ApiController]
public sealed class AuthController(IAuthService service) : ControllerBase
{
    /// <summary>
    /// Registers a new user and returns the UserDto.
    /// </summary>
    /// <returns>
    /// Returns HTTP 200 with UserDto on success.
    /// Returns HTTP 400 if the model state is invalid.
    /// Returns HTTP 409 if the email already exists.
    /// </returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var createdUser = await service.RegisterAsync(dto);
            return Ok(createdUser);
        }
        catch (ConflictException e)
        {
            return Conflict(new { message = e.Message });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new { message = e.Message });
        }
    }

    /// <summary>
    /// Logs in the user with email and password
    /// </summary>
    /// <returns>
    /// Returns HTTP 200 with UserDto on successful login.
    /// Returns HTTP 400 if the model state is invalid.
    /// Returns HTTP 401 if credentials are invalid.
    /// </returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var user = await service.LoginAsync(dto);
            return Ok(user);
        }
        catch (AuthenticationFailedException e)
        {
            return Unauthorized(new { message = e.Message });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }

    }

    /// <summary>
    /// Logs out the currently authenticated user by clearing the authentication cookie.
    /// </summary>
    /// <returns>
    /// Returns HTTP 204 No Content on success.
    /// </returns>
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return NoContent();
    }

    /// <summary>
    /// Retrieves the currently authenticated user's information.
    /// </summary>
    /// <returns>
    /// Returns HTTP 200 with UserDto for the authenticated user.
    /// Returns HTTP 401 if the user is not authenticated.
    /// Returns HTTP 404 if the user does not exist in the database.
    /// </returns>
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetMe()
    {
        var idClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(idClaim!.Value, out var id))
            return Unauthorized("Invalid session");
        try
        {
            var user = await service.GetMeAsync(id);
            return Ok(user);
        }
        catch (ResourceNotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

}