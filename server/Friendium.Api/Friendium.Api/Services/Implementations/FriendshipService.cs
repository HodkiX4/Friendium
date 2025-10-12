using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;

namespace Friendium.Api.Services.Implementations;

public class FriendshipService(IFriendshipRepository repo) : IFriendshipService
{
    public async Task<IEnumerable<Friendship>> GetFriends(Guid userId)
        => await repo.GetAllAsync(userId);

    public Task RemoveFriend(Guid friendshipId)
    {
        throw new NotImplementedException();
    }
}