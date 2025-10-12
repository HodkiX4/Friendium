using Friendium.Api.Models;

namespace Friendium.Api.Repositories.Interfaces;

public interface IFriendRequestRepository
{
    Task<FriendRequest?> GetByIdAsync(Guid id);
    Task AddAsync(FriendRequest request);
    Task AcceptAsync(Guid requestId);
    Task RejectAsync(Guid requestId);
    Task<IEnumerable<FriendRequest>> GetIncomingAsync(Guid userId);
    Task<IEnumerable<FriendRequest>> GetOutgoingAsync(Guid userId);
    Task<bool> ExistsAsync(Guid senderId, Guid receiverId);
}