using Friendium.Api.Exceptions;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;

namespace Friendium.Api.Services.Implementations;

/// <summary>
/// Service implementation for friendship business logic.
/// Provides operations for retrieving and managing user friendships.
/// </summary>
public sealed class FriendshipService(IFriendshipRepository repo) : IFriendshipService
{
    public async Task<IEnumerable<Friendship>> GetFriends(Guid userId)
        => await repo.GetAllAsync(userId);

    public async Task RemoveFriend(Guid friendshipId)
    {
        var existingFriendship = await repo.GetByIdAsync(friendshipId);
        if (existingFriendship == null)
            throw new ResourceNotFoundException("Friendship not found");

        await repo.RemoveAsync(existingFriendship);
    }
}