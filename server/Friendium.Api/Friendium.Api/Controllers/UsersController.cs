using Friendium.Api.DTOs.Request;
using Friendium.Api.Exceptions;
using Friendium.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendium.Api.Controllers;

/// <summary>
/// Controller responsible for handling user data fetching endpoints:
/// Fetching all users and fetching a single user.
/// </summary>
[Route("api/users")]
[ApiController]
[Authorize]
public sealed class UsersController(IUserService userService, IUserProfileService userProfileService) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            var users = await userService.GetUsers();
            return Ok(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchUsers()
    {
        try
        {
            var users = await userProfileService.GetAllUserSearchResults();
            return Ok(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        try
        {
            var user = await userService.GetUserById(userId);
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

    [HttpGet("profile/{userId:guid}")]
    public async Task<IActionResult> GetUserProfile([FromRoute] Guid userId)
    {
        try
        {
            var userProfile = await userProfileService.GetUserProfile(userId);
            return Ok(userProfile);
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

    [HttpPut("profile/{userId:guid}")]
    public async Task<IActionResult> UpdateUserProfile([FromRoute] Guid userId, [FromBody] UpdateUserProfileDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { message = ModelState });

        try
        {
            var updatedProfile = await userProfileService.UpdateProfile(userId, dto);
            return Ok(updatedProfile);
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

    /// <summary>
    /// Updates user information (firstname, lastname, password).
    /// </summary>
    /// <param name="userId">The user ID to update.</param>
    /// <param name="dto">The update data.</param>
    /// <returns>Returns the updated user.</returns>
    [HttpPut("{userId:guid}")]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid userId, [FromBody] UpdateUserDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { message = ModelState });

        try
        {
            var updatedUser = await userService.UpdateUser(userId, dto);
            return Ok(updatedUser);
        }
        catch (ResourceNotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
        catch (ConflictException e)
        {
            return Conflict(new { message = e.Message });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }
}