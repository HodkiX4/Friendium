using Friendium.Api.Models;
using Friendium.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Friendium.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController(IUserProfileService service) : ControllerBase
{
        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUserProfile(Guid userId)
        {
                var userProfile = await service.GetUserProfile(userId);
                if(userProfile == null)
                        return NotFound(new { message = "Profile not found" });
                return Ok(userProfile);
        }

        [HttpPut("{userId:guid}")]
        public async Task<IActionResult> UpdateUserProfile(Guid userId, UserProfile profile)
        {
                // TODO
                throw new NotImplementedException();
        }
}