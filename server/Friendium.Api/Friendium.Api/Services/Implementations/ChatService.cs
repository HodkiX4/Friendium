using Friendium.Api.Exceptions;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;

namespace Friendium.Api.Services.Implementations;

/// <summary>
/// Service implementation for chat-related operations.
/// Provides business logic for working with chats and chat lifecycle.
/// Currently a placeholder for future chat operations.
/// </summary>
public sealed class ChatService(IChatRepository chatRepository, IUserRepository userRepository) : IChatService
{
    /// <summary>
    /// Gets all chats for the specified user.
    /// </summary>
    public async Task<IEnumerable<Chat>> GetUserChats(Guid userId)
    {
        var existingUser = await userRepository.GetByIdAsync(userId);
        if (existingUser == null)
            throw new ResourceNotFoundException("User not found");
        return await chatRepository.GetAllAsync(userId);
    }

    /// <summary>
    /// Retrieves a chat by id or throws when not found.
    /// </summary>
    public async Task<Chat?> GetChatById(Guid chatId)
    {
        var existingChat = await chatRepository.GetByIdAsync(chatId);
        if (existingChat == null)
            throw new ResourceNotFoundException("Chat not found");
        return existingChat;
    }

    /// <summary>
    /// Deletes a chat by id.
    /// </summary>
    public async Task DeleteChat(Guid chatId)
    {
        var existingChat = await chatRepository.GetByIdAsync(chatId);
        if (existingChat == null)
            throw new ResourceNotFoundException("Chat not found for deletion");
        await chatRepository.RemoveAsync(existingChat);
    }

}