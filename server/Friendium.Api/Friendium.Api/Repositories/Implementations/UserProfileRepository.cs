using Friendium.Api.Data;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Friendium.Api.Repositories.Implementations;

public class UserProfileRepository(AppDbContext context) : IUserProfileRepository
{
    public async Task<UserProfile?> GetByIdAsync(Guid userId)
        => await context.UserProfiles.FindAsync(userId);

    public async Task UpdateAsync(UserProfile profile)
    {
        context.UserProfiles.Update(profile);
        await context.SaveChangesAsync();
    }
}