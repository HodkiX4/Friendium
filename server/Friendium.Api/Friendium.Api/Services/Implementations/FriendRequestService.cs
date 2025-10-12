using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;

namespace Friendium.Api.Services.Implementations;

public class FriendRequestService(
    IFriendRequestRepository friendRequestRepo, 
    IUserRepository userRepo
    ) : IFriendRequestService
{
    public async Task SendRequest(Guid senderId, Guid receiverId)
    {
        var sender = await userRepo.GetByIdAsync(senderId);
        var receiver = await userRepo.GetByIdAsync(receiverId);
        if (receiver == null && sender == null)
            throw new InvalidOperationException("Sender or Receiver doesn't exist");
        
        var exists = await friendRequestRepo.ExistsAsync(senderId, receiverId);
        if (exists)
            throw new InvalidOperationException("Friend request already exists");

        var newFriendRequest = new FriendRequest
        {
            SenderId = senderId,
            ReceiverId = receiverId,
        };
        
        await friendRequestRepo.AddAsync(newFriendRequest);
    }

    public async Task AcceptRequest(Guid requestId)
        => await friendRequestRepo.AcceptAsync(requestId);

    public Task RejectRequest(Guid requestId)
        => friendRequestRepo.RejectAsync(requestId);

    public async Task<IEnumerable<FriendRequest>> GetPendingRequests(Guid userId)
        => await friendRequestRepo.GetIncomingAsync(userId);

}