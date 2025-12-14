using Friendium.Api.Data;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Friendium.Api.Repositories.Implementations;

/// <summary>
/// Repository implementation for user profile storage.
/// Supports fetching and updating profiles associated with users.
/// </summary>
public sealed class UserProfileRepository(AppDbContext context) : IUserProfileRepository
{
    public async Task<UserProfile?> GetByIdAsync(Guid userId)
        => await context.UserProfiles.Where(p => p.UserId == userId).FirstOrDefaultAsync();

    public async Task UpdateAsync(UserProfile profile)
    {
        context.UserProfiles.Update(profile);
        await context.SaveChangesAsync();
    }
}