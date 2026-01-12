using Friendium.Api.DTOs.Request;
using Friendium.Api.DTOs.Response;
using Friendium.Api.Models;

namespace Friendium.Api.Services.Interfaces;

/// <summary>
/// Service interface for message-related business logic.
/// Provides methods to get, send, update and delete messages.
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Gets all messages for the specified chat.
    /// </summary>
    Task<IEnumerable<MessageDto>> GetMessages(Guid chatId);

    /// <summary>
    /// Gets a single message by id.
    /// </summary>
    Task<MessageDto> GetMessageById(Guid id);

    /// <summary>
    /// Sends (persists) a new message on behalf of the specified user.
    /// </summary>
    Task<MessageDto> SendMessage(Guid userId, Guid chatId, AddMessageDto message);

    /// <summary>
    /// Updates an existing message identified by id.
    /// </summary>
    Task<MessageDto> UpdateMessage(Guid id, UpdateMessageDto message);

    /// <summary>
    /// Deletes a message by id.
    /// </summary>
    Task DeleteMessage(Guid id);
}