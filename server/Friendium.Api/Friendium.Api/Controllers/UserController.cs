using Friendium.Api.DTOs;
using Friendium.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendium.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public sealed class UserController(IUserService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await service.GetUsers();
        var result = users
            .Select(u => new UserDto(u.Id.ToString(), u.Name, u.Email));
        return Ok(result);
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        var user = await service.GetUserById(userId);
        if (user == null)
            return NotFound(new { message = "User not found" });
        return Ok(new UserDto(user.Id.ToString(), user.Name, user.Email));
        
    }
}