using System.Security.Claims;
using Friendium.Api.Exceptions;
using Friendium.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendium.Api.Controllers;

/// <summary>
/// Controller responsible for chat-related endpoints.
/// Provides endpoints to retrieve chat rooms and their messages.
/// </summary>
[Authorize]
[Route("api/chats")]
[ApiController]

public sealed class ChatsController(IChatService chatService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUserChats()
    {
        var userIdStr = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(userIdStr, out var userId))
            return BadRequest();

        try
        {
            var chats = await chatService.GetUserChats(userId);
            return Ok(chats);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    /// <summary>
    /// Retrieves a chat room by its unique identifier.
    /// </summary>
    /// <param name="chatId">The unique identifier of the chat to retrieve.</param>
    /// <returns>HTTP 200 with chat data on success, otherwise HTTP 400.</returns>
    [HttpGet("{chatId:guid}")]
    public async Task<IActionResult> GetChatRoom([FromRoute] Guid chatId)
    {
        try
        {
            var chat = await chatService.GetChatById(chatId);
            return Ok(chat);
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