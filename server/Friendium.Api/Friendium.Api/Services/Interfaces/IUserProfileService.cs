using Friendium.Api.Models;

namespace Friendium.Api.Services.Interfaces;

public interface IUserProfileService
{
    Task<UserProfile?> GetUserProfile(Guid userId);
    Task<UserProfile?> UpdateProfile(UserProfile profile);
}