using Friendium.Api.DTOs.Request;

namespace Friendium.Api.Services.Interfaces;

/// <summary>
/// Service interface for friend request operations.
/// </summary>
public interface IFriendRequestService
{
    /// <summary>
    /// Sends a friend request from senderId to receiverId.
    /// </summary>
    Task SendRequest(Guid senderId, Guid receiverId);

    /// <summary>
    /// Accepts a pending friend request.
    /// </summary>
    Task AcceptRequest(Guid requestId);

    /// <summary>
    /// Rejects or removes a pending friend request.
    /// </summary>
    Task RejectRequest(Guid requestId);

    /// <summary>
    /// Gets pending incoming friend requests for a user.
    /// </summary>
    Task<IEnumerable<FriendRequestDto>> GetPendingRequests(Guid userId);
}