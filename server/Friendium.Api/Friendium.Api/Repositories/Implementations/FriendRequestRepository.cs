using Friendium.Api.Data;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Friendium.Api.Repositories.Implementations;

/// <summary>
/// Repository implementation for friend request storage.
/// Handles creation, acceptance, rejection and querying of friend requests.
/// </summary>
public sealed class FriendRequestRepository(AppDbContext context) : IFriendRequestRepository
{
    public async Task<FriendRequest?> GetByIdAsync(Guid id)
        => await context.FriendRequests.FindAsync(id);

    public async Task AddAsync(FriendRequest request)
    {
        await context.FriendRequests.AddAsync(request);
        await context.SaveChangesAsync();
    }

    public async Task AcceptAsync(FriendRequest friendRequest)
    {
        friendRequest.IsAccepted = true;
        context.FriendRequests.Update(friendRequest);
        await context.SaveChangesAsync();
    }

    public async Task RejectAsync(FriendRequest friendRequest)
    {
        context.FriendRequests.Remove(friendRequest);
        await context.SaveChangesAsync();

    }

    public async Task<IEnumerable<FriendRequest>> GetIncomingAsync(Guid userId)
        => await context.FriendRequests
            .AsNoTracking()
            .Where(fr => fr.ReceiverId == userId)
            .ToListAsync();

    public async Task<IEnumerable<FriendRequest>> GetOutgoingAsync(Guid userId)
        => await context.FriendRequests
            .AsNoTracking()
            .Where(fr => fr.SenderId == userId)
            .ToListAsync();

    public async Task<bool> ExistsAsync(Guid senderId, Guid receiverId)
        => await context.FriendRequests
            .AnyAsync(fr =>
                (fr.SenderId == senderId && fr.ReceiverId == receiverId) ||
                (fr.SenderId == receiverId && fr.ReceiverId == senderId));
}