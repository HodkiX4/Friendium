using Friendium.Api.DTOs;
using Friendium.Api.Models;
using Friendium.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendium.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public sealed class UserProfileController(IUserProfileService service) : ControllerBase
{
        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUserProfile(Guid userId)
        {
                var userProfile = await service.GetUserProfile(userId);
                if(userProfile == null)
                        return NotFound(new { message = "Profile not found" });
                return Ok(new UserProfileDto(
                        userProfile.UserId,
                        userProfile.AvatarUrl,
                        userProfile.Bio,
                        userProfile.DateOfBirth,
                        userProfile.Gender,
                        userProfile.Interests,
                        userProfile.City,
                        userProfile.Country,
                        userProfile.Latitude,
                        userProfile.Longitude,
                        userProfile.IsVisible)
                );
        }

        [HttpPut("{userId:guid}")]
        public async Task<IActionResult> UpdateUserProfile([FromRoute] Guid userId, [FromBody] UpdateUserProfileDto dto)
        {
                if(!ModelState.IsValid)
                        return BadRequest(ModelState);
                
                var updatedUserProfile = await service.UpdateProfile(userId, dto);
                if(updatedUserProfile == null)
                        return NotFound("Profile not found");
                
                return Ok(new UserProfileDto(
                        updatedUserProfile.UserId,
                        updatedUserProfile.AvatarUrl,
                        updatedUserProfile.Bio,
                        updatedUserProfile.DateOfBirth,
                        updatedUserProfile.Gender,
                        updatedUserProfile.Interests,
                        updatedUserProfile.City,
                        updatedUserProfile.Country,
                        updatedUserProfile.Latitude,
                        updatedUserProfile.Longitude,
                        updatedUserProfile.IsVisible)
                );
        }
}