using System.Security.Claims;
using Friendium.Api.DTOs;
using Friendium.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendium.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public sealed class FriendRequestController(IFriendRequestService service) : ControllerBase
{
    [HttpGet("pending")]
    public async Task<IActionResult> GetPendingRequests()
    {
        var userIdStr = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if(!Guid.TryParse(userIdStr, out var userId))
            return BadRequest();
        
        var requests = await service.GetPendingRequests(userId);
        var result = requests.Select(fr =>
            new FriendRequestDto(fr.Id, fr.SenderId, fr.ReceiverId, fr.SentAt, fr.IsAccepted)
        );
        return Ok(result);
    }
    
    [HttpPost("{receiverId:guid}")]
    public async Task<IActionResult> SendFriendRequest([FromRoute] Guid receiverId)
    {
        var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if(!Guid.TryParse(userIdStr, out var senderId))
            return Unauthorized();

        try
        {
            await service.SendRequest(senderId, receiverId);
            return Ok(new { Message = "Friend request sent." });
        }
        catch (Exception e)
        {
            return BadRequest(new { e.Message });
        }
        
    }

    [HttpGet("{requestId:guid}")]
    public async Task<IActionResult> AcceptFriendRequest([FromRoute] Guid requestId)
    {
        var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if(!Guid.TryParse(userIdStr, out var senderId))
            return Unauthorized();
        try
        {
            await service.AcceptRequest(requestId);
            return Ok(new { Message = "Friend request accepted." });
        }
        catch (Exception e)
        {
            return BadRequest(new { e.Message });
        }

    }

    [HttpDelete("{requestId:guid}")]
    public async Task<IActionResult> RejectFriendRequest([FromRoute] Guid requestId)
    {
        var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if(!Guid.TryParse(userIdStr, out var userId))
            return Unauthorized();
        try
        {
            await service.RejectRequest(requestId);
            return Ok(new { Message = "Friend request rejected." });
        }
        catch (Exception e)
        {
            return BadRequest(new { e.Message });
        }
    }
    
}