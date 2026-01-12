using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;
using Friendium.Api.Exceptions;
using Friendium.Api.DTOs.Request;
using System.Security.Claims;
using Friendium.Api.DTOs.Response;

namespace Friendium.Api.Services.Implementations;

/// <summary>
/// Service implementation for message business logic.
/// Wraps repository operations and applies simple validation (user/chat existence) when sending messages.
/// </summary>
public sealed class MessageService(IMessageRepository repo) : IMessageService
{

    /// <summary>
    /// Gets a single message by id.
    /// </summary>
    public async Task<MessageDto> GetMessageById(Guid id)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing == null)
            throw new ResourceNotFoundException("Message not found");
        return new MessageDto
        (
            existing.Id,
            existing.ChatId,
            existing.UserId,
            existing.Text,
            existing.UpdatedAt
        );
    }

    /// <summary>
    /// Gets all messages for a chat.
    /// </summary>
    public async Task<IEnumerable<MessageDto>> GetMessages(Guid chatId)
    {
        var messages = await repo.GetAllAsync(chatId);
        return messages.Select(m => new MessageDto(
            m.Id,
            m.ChatId,
            m.UserId,
            m.Text,
            m.UpdatedAt
        ));
    }

    /// <summary>
    /// Persists a new message after basic validation.
    /// </summary>
    public async Task<MessageDto> SendMessage(Guid userId, Guid chatId, AddMessageDto dto)
    {

        var message = new Message
        {
            ChatId = chatId,
            UserId = userId,
            Text = dto.Text,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        await repo.AddAsync(message);

        return new MessageDto
        (
            message.Id,
            message.ChatId,
            message.UserId,
            message.Text,
            message.UpdatedAt
        );
    }

    /// <summary>
    /// Updates an existing message. Implementations may choose to validate ownership.
    /// </summary>
    public async Task<MessageDto> UpdateMessage(Guid id, UpdateMessageDto dto)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing == null)
            throw new ResourceNotFoundException("Message not found");

        // Apply updatable fields
        existing.Text = dto.Text;
        existing.UpdatedAt = DateTime.UtcNow;

        await repo.UpdateAsync(existing);

        return new MessageDto
        (
            existing.Id,
            existing.ChatId,
            existing.UserId,
            existing.Text,
            existing.UpdatedAt
        );
    }

    /// <summary>
    /// Deletes a message by id.
    /// </summary>
    public async Task DeleteMessage(Guid id)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing == null)
            throw new ResourceNotFoundException("Message not found");

        await repo.RemoveAsync(existing);
    }

}