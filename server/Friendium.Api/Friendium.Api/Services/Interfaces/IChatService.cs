using Friendium.Api.Models;

namespace Friendium.Api.Services.Interfaces;

/// <summary>
/// Service interface for chat-related business logic.
/// Implementations should provide operations to manage chats and deliver chat data to controllers.
/// </summary>
public interface IChatService
{
    Task<IEnumerable<Chat>> GetUserChats(Guid userId);

    Task<Chat?> GetChatById(Guid chatId);

    Task DeleteChat(Guid chatId);

}