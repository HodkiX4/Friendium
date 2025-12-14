using Friendium.Api.Models;

namespace Friendium.Api.Services.Interfaces;

/// <summary>
/// Service interface for friendship operations.
/// </summary>
public interface IFriendshipService
{
    /// <summary>
    /// Gets friends for the specified user.
    /// </summary>
    Task<IEnumerable<Friendship>> GetFriends(Guid userId);

    /// <summary>
    /// Removes a friendship record by its id.
    /// </summary>
    Task RemoveFriend(Guid friendshipId);
}