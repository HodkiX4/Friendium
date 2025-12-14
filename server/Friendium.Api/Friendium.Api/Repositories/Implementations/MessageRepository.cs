using Friendium.Api.Data;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Friendium.Api.Repositories.Implementations;

/// <summary>
/// Repository implementation for message storage and retrieval.
/// Provides methods to add, update and remove chat messages.
/// </summary>
public sealed class MessageRepository(AppDbContext context) : IMessageRepository
{
    public async Task<IEnumerable<Message>> GetAllAsync(Guid chatId)
        => await context.Messages
            .Where(m => m.ChatId == chatId)
            .ToListAsync();

    public async Task AddAsync(Message message)
    {
        await context.Messages.AddAsync(message);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Message message)
    {
        context.Messages.Update(message);
        await context.SaveChangesAsync();

    }

    public async Task RemoveAsync(Message message)
    {
        context.Messages.Remove(message);
        await context.SaveChangesAsync();
    }
}