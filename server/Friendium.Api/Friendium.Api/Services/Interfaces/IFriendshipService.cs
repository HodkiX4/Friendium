using Friendium.Api.Models;

namespace Friendium.Api.Services.Interfaces;

public interface IFriendshipService
{
    Task<IEnumerable<Friendship>> GetFriends(Guid userId);
    Task RemoveFriend(Guid friendshipId);
}