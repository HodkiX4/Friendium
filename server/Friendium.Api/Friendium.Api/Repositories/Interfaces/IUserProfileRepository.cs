using Friendium.Api.Models;

namespace Friendium.Api.Repositories.Interfaces;

/// <summary>
/// Provides access to user profile storage
/// </summary>
public interface IUserProfileRepository
{
    /// <summary>
    /// Tries to get the profile data of a user based on its unique identifier. 
    /// </summary>
    /// <param name="userId">The unique identifier of the user</param>
    /// <returns>The profile of the user or null, if it doesn't exist</returns>
    Task<UserProfile?> GetByIdAsync(Guid userId);
    
    /// <summary>
    /// Updates the profile of the user based on a new model.
    /// </summary>
    /// <param name="profile">A new model with modified values</param>
    Task UpdateAsync(UserProfile profile);
}