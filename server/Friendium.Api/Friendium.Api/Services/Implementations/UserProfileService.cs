using Friendium.Api.DTOs.Request;
using Friendium.Api.DTOs.Response;
using Friendium.Api.Exceptions;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;

namespace Friendium.Api.Services.Implementations;

/// <summary>
/// Service implementation for user profile operations.
/// Handles the fetching of a user profile, and the updating of the user profile.
/// </summary>
public sealed class UserProfileService(IUserProfileRepository repo) : IUserProfileService
{
    public async Task<IEnumerable<UserSearchResultDto>> GetAllUserSearchResults()
    {
        var profiles = await repo.GetAllAsync();
        return profiles.
            Where(p => p.IsVisible)
            .Select(p => new UserSearchResultDto(
                p.UserId,
                (p.User?.Firstname + " " + p.User?.Lastname).Trim(),
                p.AvatarUrl,
                string.IsNullOrWhiteSpace(p.Bio) ? null : p.Bio,
                p.Interests,
                p.City,
                p.Country,
                p.IsVisible,
                p.Gender
            ));
    }

    public async Task<UserProfileDto?> GetUserProfile(Guid userId)
    {
        var existingProfile = await repo.GetByIdAsync(userId);
        if (existingProfile == null)
            throw new ResourceNotFoundException("User profile not found");
        return new UserProfileDto(
            existingProfile.Id,
            existingProfile.UserId,
            existingProfile.AvatarUrl,
            existingProfile.Bio,
            existingProfile.DateOfBirth,
            existingProfile.Gender,
            existingProfile.Interests,
            existingProfile.City,
            existingProfile.Country,
            existingProfile.Latitude,
            existingProfile.Longitude,
            existingProfile.IsVisible
        );
    }

    public async Task<UserProfileDto?> UpdateProfile(Guid userId, UpdateUserProfileDto dto)
    {
        var existingProfile = await repo.GetByIdAsync(userId);
        if (existingProfile == null)
            throw new ResourceNotFoundException("User profile not found");

        if (dto.AvatarUrl != null)
            existingProfile.AvatarUrl = dto.AvatarUrl;
        if (dto.Bio != null)
            existingProfile.Bio = dto.Bio;
        if (dto.City != null)
            existingProfile.City = dto.City;
        if (dto.Country != null)
            existingProfile.Country = dto.Country;
        if (dto.DateOfBirth.HasValue)
            existingProfile.DateOfBirth = dto.DateOfBirth.Value;
        if (dto.Gender.HasValue)
            existingProfile.Gender = dto.Gender.Value;
        if (dto.Interests != null)
            existingProfile.Interests = dto.Interests;
        if (dto.IsVisible.HasValue)
            existingProfile.IsVisible = dto.IsVisible.Value;

        await repo.UpdateAsync(existingProfile);
        return new UserProfileDto(
            existingProfile.Id,
            existingProfile.UserId,
            existingProfile.AvatarUrl,
            existingProfile.Bio,
            existingProfile.DateOfBirth,
            existingProfile.Gender,
            existingProfile.Interests,
            existingProfile.City,
            existingProfile.Country,
            existingProfile.Latitude,
            existingProfile.Longitude,
            existingProfile.IsVisible
        );
    }
}