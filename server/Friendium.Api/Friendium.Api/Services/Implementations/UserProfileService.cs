using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;

namespace Friendium.Api.Services.Implementations;

public class UserProfileService(IUserProfileRepository repo) : IUserProfileService
{
    public async Task<UserProfile?> GetUserProfile(Guid userId)
        => await repo.GetByIdAsync(userId);
    
    public async Task<UserProfile?> UpdateProfile(UserProfile profile)
    {
        var existingProfile = await repo.GetByIdAsync(profile.Id);
        if (existingProfile == null) return null;
        
        await repo.UpdateAsync(profile);
        return profile;
    }
}