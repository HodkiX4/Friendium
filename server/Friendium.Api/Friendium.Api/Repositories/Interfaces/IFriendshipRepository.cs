using Friendium.Api.Models;

namespace Friendium.Api.Repositories.Interfaces;

public interface IFriendshipRepository
{
    Task<IEnumerable<Friendship>> GetAllAsync(Guid userId);
    Task RemoveAsync(Guid id);
}