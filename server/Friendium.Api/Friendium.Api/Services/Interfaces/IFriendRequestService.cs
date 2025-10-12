using Friendium.Api.Models;

namespace Friendium.Api.Services.Interfaces;

public interface IFriendRequestService
{
    Task SendRequest(Guid senderId, Guid receiverId);
    Task AcceptRequest(Guid requestId);
    Task RejectRequest(Guid requestId);
    Task<IEnumerable<FriendRequest>> GetPendingRequests(Guid userId);
}