using Friendium.Api.DTOs;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;

namespace Friendium.Api.Services.Implementations;

public class UserProfileService(IUserProfileRepository repo) : IUserProfileService
{
    public async Task<UserProfile?> GetUserProfile(Guid userId)
        => await repo.GetByIdAsync(userId);
    
    public async Task<UserProfile?> UpdateProfile(Guid userId, UpdateUserProfileDto dto)
    {
        var existingProfile = await repo.GetByIdAsync(userId);
        if (existingProfile == null) return null;
        
        if(dto.AvatarUrl != null)
            existingProfile.AvatarUrl = dto.AvatarUrl;
        if(dto.Bio != null)
            existingProfile.Bio = dto.Bio;
        if(dto.City != null)
            existingProfile.City = dto.City;
        if(dto.Country != null)
            existingProfile.Country = dto.Country;
        if(dto.DateOfBirth.HasValue)
            existingProfile.DateOfBirth = dto.DateOfBirth.Value;
        if(dto.Gender.HasValue)
            existingProfile.Gender = dto.Gender.Value;
        if(dto.Interests != null)
            existingProfile.Interests = dto.Interests;
        if(dto.IsVisible.HasValue)
            existingProfile.IsVisible = dto.IsVisible.Value;
        
        await repo.UpdateAsync(existingProfile);
        return existingProfile;
    }
}