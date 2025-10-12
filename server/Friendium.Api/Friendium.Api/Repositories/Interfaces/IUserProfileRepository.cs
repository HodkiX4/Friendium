using Friendium.Api.Models;

namespace Friendium.Api.Repositories.Interfaces;

public interface IUserProfileRepository
{
    Task<UserProfile?> GetByIdAsync(Guid userId);
    Task UpdateAsync(UserProfile profile);
}