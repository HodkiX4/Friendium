using Friendium.Api.Models;

namespace Friendium.Api.Repositories.Interfaces;

/// <summary>
/// Provides access to user data storage.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Gets all registered users from the database
    /// </summary>
    /// <returns>Returns a list of all users</returns>
    Task<IEnumerable<User>> GetAllAsync();

    /// <summary>
    /// Tries to get the user from the database based on its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <returns>Returns the user or null, if it doesn't exist</returns>
    Task<User?> GetByIdAsync(Guid id);

    /// <summary>
    /// Tries to get the user from the database base on its email address
    /// </summary>
    /// <param name="email">The email of the user</param>
    /// <returns>Returns the user or null, if it doesn't exist</returns>
    Task<User?> GetByEmailAsync(string email);

    /// <summary>
    /// Adds a new user to the database
    /// </summary>
    /// <param name="user">The data of the user we want to save to the database</param>
    Task AddAsync(User user);

    /// <summary>
    /// Updates the fields of an exising user in the database
    /// </summary>
    /// <param name="user">The updated user object</param>
    Task UpdateAsync(User user);

    /// <summary>
    /// Removes an existing user from the database
    /// </summary>
    /// <param name="user">The user we want to delete</param>
    /// <returns></returns>
    Task RemoveAsync(User user);
}