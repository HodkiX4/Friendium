using System.Security.Claims;
using Friendium.Api.DTOs.Request;
using Friendium.Api.DTOs.Response;
using Friendium.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendium.Api.Controllers;

[Authorize]
[Route("api/messages")]
[ApiController]
public class MessagesController(IMessageService messageService) : ControllerBase
{

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetMessageById(Guid id)
    {
        try
        {
            var message = await messageService.GetMessageById(id);
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpPost("/{chatId:guid}")]
    public async Task<IActionResult> SendMessage([FromRoute] Guid chatId, [FromBody] AddMessageDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(idClaim, out var userId))
            return Unauthorized("Invalid session");

        try
        {
            var message = await messageService.SendMessage(userId, chatId, dto);
            return CreatedAtAction(nameof(GetMessageById), new { id = message.Id }, message);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpPut("{messageId:guid}")]
    public async Task<IActionResult> UpdateMessage([FromRoute] Guid messageId, [FromBody] UpdateMessageDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var message = await messageService.UpdateMessage(messageId, dto);
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpDelete("{messageId:guid}")]
    public async Task<IActionResult> DeleteMessage([FromRoute] Guid messageId)
    {
        try
        {
            await messageService.DeleteMessage(messageId);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

}