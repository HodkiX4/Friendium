using Friendium.Api.Models;

namespace Friendium.Api.Repositories.Interfaces;

/// <summary>
/// Repository interface for storing and retrieving user activity entries.
/// </summary>
public interface IUserActivityRepository
{
    /// <summary>
    /// Gets activity entries for a given user.
    /// </summary>
    Task<IEnumerable<UserActivity>> GetAllAsync(Guid userId);

    /// <summary>
    /// Adds a new activity entry.
    /// </summary>
    Task AddAsync(UserActivity activity);

    /// <summary>
    /// Removes an activity entry.
    /// </summary>
    Task RemoveAsync(UserActivity activity);
}