using Friendium.Api.Data;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Friendium.Api.Repositories.Implementations;

public class UserActivityRepository(AppDbContext context) : IUserActivityRepository
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

    public async Task RemoveAsync(Guid id)
    {
        var activity = await context.UserActivities.FindAsync(id);
        if (activity != null)
        {
            context.UserActivities.Remove(activity);
            await context.SaveChangesAsync();
        }
    }
}