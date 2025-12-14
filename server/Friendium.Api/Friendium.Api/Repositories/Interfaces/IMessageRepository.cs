using Friendium.Api.Models;

namespace Friendium.Api.Repositories.Interfaces;

/// <summary>
/// Provides access to Message storage
/// </summary>
public interface IMessageRepository
{
    /// <summary>
    /// Get all messages from the current chat.
    /// </summary>
    /// <param name="chatId">The unique identifier of the currently selected chat</param>
    /// <returns>A list of messages</returns>
    Task<IEnumerable<Message>> GetAllAsync(Guid chatId);

    /// <summary>
    /// Adds a new message to a chat.
    /// </summary>
    /// <param name="message">The message we want to add to the chat</param>
    Task AddAsync(Message message);

    /// <summary>
    /// Updates a chat message sent by the user. 
    /// </summary>
    /// <param name="message">The message we want to add to upate</param>
    Task UpdateAsync(Message message);

    /// <summary>
    /// Removes a chat message sent by the user
    /// </summary>
    /// <param name="message">The message we want to remove</param>
    Task RemoveAsync(Message message);
}