using Friendium.Api.Models;

namespace Friendium.Api.Repositories.Interfaces;

public interface IUserActivityRepository
{
    Task<IEnumerable<UserActivity>> GetAllAsync(Guid userId);
    Task AddAsync(UserActivity activity);
    Task RemoveAsync(Guid id);
}