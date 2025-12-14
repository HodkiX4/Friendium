using Friendium.Api.Models;

namespace Friendium.Api.Repositories.Interfaces;

/// <summary>
/// Provides access to friendship storage
/// </summary>
public interface IFriendshipRepository
{
    /// <summary>
    /// Gets all the friends of the user. 
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>A list of the users friends</returns>
    Task<IEnumerable<Friendship>> GetAllAsync(Guid userId);

    /// <summary>
    /// Gets a friendship by its unique identifier.
    /// </summary>
    /// <param name="friendshipId">The unique identifier of the friendship.</param>
    /// <returns>Returns the friendship, if it exists, otherwise returns null.</returns>
    Task<Friendship?> GetByIdAsync(Guid friendshipId);

    /// <summary>
    /// Removes the friendship between users.
    /// </summary>
    /// <param name="id">The friend we want to remove.</param>
    Task RemoveAsync(Friendship friendship);
}