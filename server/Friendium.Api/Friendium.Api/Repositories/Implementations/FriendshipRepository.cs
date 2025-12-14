using Friendium.Api.Data;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Friendium.Api.Repositories.Implementations;

/// <summary>
/// Repository implementation for friendship records.
/// Provides methods to query and remove friendships for a user.
/// </summary>
public sealed class FriendshipRepository(AppDbContext context) : IFriendshipRepository
{
    public async Task<IEnumerable<Friendship>> GetAllAsync(Guid userId)
        => await context.Friendships
            .AsNoTracking()
            .Where(fs => fs.UserId == userId)
            .ToListAsync();

    public async Task<Friendship?> GetByIdAsync(Guid friendshipId)
        => await context.Friendships.FindAsync(friendshipId);

    public async Task RemoveAsync(Friendship friendship)
    {
        context.Friendships.Remove(friendship);
        await context.SaveChangesAsync();
    }
}