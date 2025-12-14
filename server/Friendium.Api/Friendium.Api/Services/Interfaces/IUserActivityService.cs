using Friendium.Api.Models;

namespace Friendium.Api.Services.Interfaces;

/// <summary>
/// Service interface for managing user activity entries.
/// </summary>
public interface IUserActivityService
{
    /// <summary>
    /// Retrieves user activity entries. The meaning of <c>action</c> can be defined by the implementation.
    /// </summary>
    Task<IEnumerable<UserActivity>> GetActivities(Guid userId, string action);

    /// <summary>
    /// Logs a new user activity.
    /// </summary>
    Task LogActivity(UserActivity activity);

    /// <summary>
    /// Deletes an activity entry by id.
    /// </summary>
    Task DeleteActivity(Guid activityId);
}