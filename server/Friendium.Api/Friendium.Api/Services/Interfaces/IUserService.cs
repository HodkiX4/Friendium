using Friendium.Api.DTOs;
using Friendium.Api.DTOs.Request;
using Friendium.Api.DTOs.Response;
using Friendium.Api.Models;

namespace Friendium.Api.Services.Interfaces;

/// <summary>
/// Service interface for fetching users.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Gets users from the user repository.
    /// </summary>
    Task<IEnumerable<UserDto>> GetUsers();

    /// <summary>
    /// Gets a user by its unique identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user we want to get.</param>
    /// <returns>Returns a user, if it exists, otherwise null.</returns>
    Task<UserDto?> GetUserById(Guid userId);

    /// <summary>
    /// Updates a user's information (name, email, password).
    /// </summary>
    /// <param name="userId">The unique identifier of the user to update.</param>
    /// <param name="dto">The update data transfer object.</param>
    /// <returns>Returns the updated user.</returns>
    Task<UserDto?> UpdateUser(Guid userId, UpdateUserDto dto);
}