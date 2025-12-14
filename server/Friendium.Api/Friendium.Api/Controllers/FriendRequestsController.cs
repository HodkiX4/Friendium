using System.Security.Claims;
using Friendium.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendium.Api.Controllers;

/// <summary>
/// Controller for managing friend requests between users.
/// Supports sending, listing, accepting and rejecting friend requests.
/// </summary>
[Route("api/friends/request")]
[ApiController]
[Authorize]
public sealed class FriendRequestsController(IFriendRequestService service) : ControllerBase
{
    /// <summary>
    /// Retrieves incoming friend requests for the authenticated user.
    /// </summary>
    /// <returns>HTTP 200 with pending requests on success, otherwise an error status.</returns>
    [HttpGet("pending")]
    public async Task<IActionResult> GetPendingRequests()
    {
        var userIdStr = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(userIdStr, out var userId))
            return BadRequest();

        try
        {
            var requests = await service.GetPendingRequests(userId);
            return Ok(requests);
        }
        catch (Exception e)
        {
            return BadRequest(new { e.Message });
        }
    }

    /// <summary>
    /// Sends a friend request from the authenticated user to the specified receiver.
    /// </summary>
    /// <param name="receiverId">The unique identifier of the user to receive the request.</param>
    /// <returns>HTTP 200 when the request is sent, otherwise an error status.</returns>
    [HttpPost("{receiverId:guid}")]
    public async Task<IActionResult> SendFriendRequest([FromRoute] Guid receiverId)
    {
        var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(userIdStr, out var senderId))
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

    /// <summary>
    /// Accepts a friend request by its identifier.
    /// </summary>
    /// <param name="requestId">The unique identifier of the friend request to accept.</param>
    /// <returns>HTTP 200 when accepted, otherwise an error status.</returns>
    [HttpGet("{requestId:guid}")]
    public async Task<IActionResult> AcceptFriendRequest([FromRoute] Guid requestId)
    {
        var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(userIdStr, out var senderId))
            return Unauthorized(new { message = "Unauthorized access" });
        try
        {
            await service.AcceptRequest(requestId);
            return Ok(new { message = "Friend request accepted." });
        }
        catch (Exception e)
        {
            return BadRequest(new { messagee = e.Message });
        }

    }

    /// <summary>
    /// Rejects (deletes) a friend request by its identifier.
    /// </summary>
    /// <param name="requestId">The unique identifier of the friend request to reject.</param>
    /// <returns>HTTP 200 when rejected, otherwise an error status.</returns>
    [HttpDelete("{requestId:guid}")]
    public async Task<IActionResult> RejectFriendRequest([FromRoute] Guid requestId)
    {
        var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(userIdStr, out var userId))
            return Unauthorized(new { message = "Unauthorized access" });
        try
        {
            await service.RejectRequest(requestId);
            return Ok(new { Message = "Friend request rejected." });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

}