using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;

namespace Friendium.Api.Services.Implementations;

public class UserActivityService(IUserActivityRepository repo) : IUserActivityService
{
    public Task<IEnumerable<UserActivity>> GetActivities(Guid userId, string action)
    {
        throw new NotImplementedException();
    }

    public Task LogActivity(UserActivity activity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteActivity(Guid activityId)
        => throw new NotImplementedException();
}