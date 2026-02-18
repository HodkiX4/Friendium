using Friendium.Api.DTOs.Request;
using Friendium.Api.Exceptions;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;

namespace Friendium.Api.Services.Implementations;

/// <summary>
/// Service implementation for handling friend requests.
/// Implements sending, accepting, rejecting and listing pending requests.
/// </summary>
public sealed class FriendRequestService(
    IFriendRequestRepository friendRequestRepo,
    IUserRepository userRepo,
    IFriendshipRepository friendshipRepo
    ) : IFriendRequestService
{
    public async Task SendRequest(Guid senderId, Guid receiverId)
    {
        var sender = await userRepo.GetByIdAsync(senderId);
        var receiver = await userRepo.GetByIdAsync(receiverId);
        if (receiver == null && sender == null)
            throw new ResourceNotFoundException("Sender or Receiver doesn't exist");

        var exists = await friendRequestRepo.ExistsAsync(senderId, receiverId);
        if (exists)
            throw new ConflictException("Friend request already exists");

        var newFriendRequest = new FriendRequest
        {
            SenderId = senderId,
            ReceiverId = receiverId,
        };

        await friendRequestRepo.AddAsync(newFriendRequest);
    }

    public async Task AcceptRequest(Guid requestId)
    {
        var friendRequest = await friendRequestRepo.GetByIdAsync(requestId);
        if (friendRequest == null)
            throw new ResourceNotFoundException("Friend request not found");

        var friendship1 = new Friendship
        {
            UserId = friendRequest.SenderId,
            FriendId = friendRequest.ReceiverId
        };

        var friendship2 = new Friendship
        {
            UserId = friendRequest.ReceiverId,
            FriendId = friendRequest.SenderId
        };

        await friendshipRepo.AddAsync(friendship1);
        await friendshipRepo.AddAsync(friendship2);

        await friendRequestRepo.RemoveAsync(friendRequest);
    }

    public async Task RejectRequest(Guid requestId)
    {
        var friendRequest = await friendRequestRepo.GetByIdAsync(requestId);
        if (friendRequest == null)
            throw new ResourceNotFoundException("Friend request not found");
        await friendRequestRepo.RemoveAsync(friendRequest);
    }

    public async Task<IEnumerable<FriendRequestDto>> GetPendingRequests(Guid userId)
    {
        var requests = await friendRequestRepo.GetIncomingAsync(userId);
        return requests.Select(fr => new FriendRequestDto(
            fr.Id,
            fr.SenderId,
            fr.ReceiverId,
            fr.SentAt,
            fr.IsAccepted
            ));
    }
}