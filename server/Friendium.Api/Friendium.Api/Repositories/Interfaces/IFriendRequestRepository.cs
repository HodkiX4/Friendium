using Friendium.Api.Models;

namespace Friendium.Api.Repositories.Interfaces;

/// <summary>
/// Provides access to friend request storage.
/// </summary>
public interface IFriendRequestRepository
{

    /// <summary>
    /// Tries to get a friend request by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the friend request.</param>
    /// <returns>Returns the friend request, if it exists, otherwise returns null.</returns>
    Task<FriendRequest?> GetByIdAsync(Guid id);

    /// <summary>
    /// Adds a friend request.
    /// </summary>
    /// <param name="request">The friend request we want to add.</param>
    Task AddAsync(FriendRequest request);

    /// <summary>
    /// Accepts a friend request.
    /// </summary>
    /// <param name="request">The friend request we want to accept.</param>
    Task AcceptAsync(FriendRequest friendRequest);

    /// <summary>
    /// Rejects a friend request.
    /// </summary>
    /// <param name="request">The friend request we want to reject.</param>
    Task RejectAsync(FriendRequest friendRequest);

    /// <summary>
    /// Gets the friend requests received by the specified user.
    /// </summary>
    Task<IEnumerable<FriendRequest>> GetIncomingAsync(Guid userId);

    /// <summary>
    /// Gets the friend requests sent by the specified user.
    /// </summary>
    Task<IEnumerable<FriendRequest>> GetOutgoingAsync(Guid userId);
    Task<bool> ExistsAsync(Guid senderId, Guid receiverId);
}