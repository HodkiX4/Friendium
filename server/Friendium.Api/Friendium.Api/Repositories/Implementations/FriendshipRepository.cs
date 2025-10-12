using Friendium.Api.Data;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Friendium.Api.Repositories.Implementations;

public class FriendshipRepository(AppDbContext context) : IFriendshipRepository
{
    public async Task<IEnumerable<Friendship>> GetAllAsync(Guid userId)
        => await context.Friendships
            .AsNoTracking()
            .Where(fs => fs.UserId == userId)
            .ToListAsync();

    public async Task RemoveAsync(Guid id)
    {
        var friendship = await context.Friendships.FindAsync(id);
        if (friendship != null)
        {
            context.Friendships.Remove(friendship);
            await context.SaveChangesAsync();
        }
    }
}