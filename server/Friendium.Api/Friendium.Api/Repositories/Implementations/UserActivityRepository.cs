using Friendium.Api.Data;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Friendium.Api.Repositories.Implementations;

/// <summary>
/// Repository implementation for user activity records.
/// Handles logging, retrieval and removal of user activity entries.
/// </summary>
public sealed class UserActivityRepository(AppDbContext context) : IUserActivityRepository
{
    public async Task<IEnumerable<UserActivity>> GetAllAsync(Guid userId)
        => await context.UserActivities
            .AsNoTracking()
            .Where(a => a.UserId == userId)
            .ToListAsync();

    public async Task AddAsync(UserActivity activity)
    {
        await context.UserActivities.AddAsync(activity);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(UserActivity activity)
    {
        context.UserActivities.Remove(activity);
        await context.SaveChangesAsync();
    }
}