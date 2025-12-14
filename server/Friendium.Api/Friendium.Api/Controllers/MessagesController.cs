using Friendium.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendium.Api.Controllers;

[Authorize]
[Route("api/messages")]
[ApiController]
public class MessagesController(IMessageService messageService) : ControllerBase
{
    public async Task<IActionResult> GetMessagesForChat(Guid chatId)
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

    public async Task<IActionResult> SendMessage()
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

    public async Task<IActionResult> UpdateMessage(Guid messageId)
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

    public async Task<IActionResult> DeleteMessage(Guid messageId)
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