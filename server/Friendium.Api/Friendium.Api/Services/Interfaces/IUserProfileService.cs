using Friendium.Api.DTOs.Request;
using Friendium.Api.DTOs.Response;

namespace Friendium.Api.Services.Interfaces;

/// <summary>
/// Service interface for user profile operations.
/// </summary>
public interface IUserProfileService
{
    Task<IEnumerable<UserSearchResultDto>> GetAllUserSearchResults();
    /// <summary>
    /// Gets a user's profile by their unique identifier.
    /// </summary>
    Task<UserProfileDto?> GetUserProfile(Guid userId);

    /// <summary>
    /// Updates the profile for the specified user using the provided DTO.
    /// Returns the updated profile DTO or null if the profile/user does not exist.
    /// </summary>
    Task<UserProfileDto?> UpdateProfile(Guid userId, UpdateUserProfileDto profile);
}