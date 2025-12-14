using Friendium.Api.Models;

namespace Friendium.Api.Repositories.Interfaces;

/// <summary>
/// Repository interface for chat persistence and retrieval.
/// </summary>
public interface IChatRepository
{
    /// <summary>
    /// Gets all chats the specified user participates in.
    /// </summary>
    Task<IEnumerable<Chat>> GetAllAsync(Guid userId);

    /// <summary>
    /// Tries to get a chat by its unique identifier.
    /// </summary>
    Task<Chat?> GetByIdAsync(Guid id);

    /// <summary>
    /// Adds a new chat.
    /// </summary>
    Task AddAsync(Chat chat);

    /// <summary>
    /// Removes a chat.
    /// </summary>
    Task RemoveAsync(Chat chat);
}