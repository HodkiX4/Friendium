using Friendium.Api.Models;

namespace Friendium.Api.Services.Interfaces;

public interface IUserActivityService
{
    Task<IEnumerable<UserActivity>> GetActivities(Guid userId, string action);
    Task LogActivity(UserActivity activity);
    Task DeleteActivity(Guid activityId);
}