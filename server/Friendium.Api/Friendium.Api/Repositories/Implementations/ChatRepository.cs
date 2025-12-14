using Friendium.Api.Data;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Friendium.Api.Repositories.Implementations;

/// <summary>
/// Repository implementation for chat storage and retrieval.
/// Handles persistence operations for Chat entities.
/// </summary>
public sealed class ChatRepository(AppDbContext context) : IChatRepository
{
    public async Task<IEnumerable<Chat>> GetAllAsync(Guid userId)
        => await context.Chats
            .Where(c => c.UserIds.Contains(userId))
            .ToListAsync();


    public async Task<Chat?> GetByIdAsync(Guid id)
        => await context.Chats.FindAsync(id);

    public async Task AddAsync(Chat chat)
    {
        await context.Chats.AddAsync(chat);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Chat chat)
    {
        context.Chats.Remove(chat);
        await context.SaveChangesAsync();
    }
}