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

public class ChatsController(IChatService chatService) : ControllerBase
{
    /// <summary>
    /// Retrieves a chat room by its unique identifier.
    /// </summary>
    /// <param name="chatId">The unique identifier of the chat to retrieve.</param>
    /// <returns>HTTP 200 with chat data on success, otherwise HTTP 400.</returns>
    [HttpGet("{chatId}")]
    public async Task<IActionResult> GetChatRoom(Guid chatId)
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

}