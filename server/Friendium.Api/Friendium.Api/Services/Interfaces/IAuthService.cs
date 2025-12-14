using Friendium.Api.DTOs;
using Friendium.Api.DTOs.Request;
using Friendium.Api.DTOs.Response;
using Friendium.Api.Models;

namespace Friendium.Api.Services.Interfaces;

/// <summary>
/// Service interface for authentication operations.
/// Provides login, registration and retrieval of the current user.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Validates credentials and signs in the user using cookie authentication.
    /// Returns the authenticated user's <see cref="DTOs.Response.UserDto"/>.
    /// </summary>
    Task<UserDto> LoginAsync(LoginDto dto);

    /// <summary>
    /// Registers a new user and signs them in. Returns the created user's DTO.
    /// </summary>
    Task<UserDto> RegisterAsync(RegisterDto dto);

    /// <summary>
    /// Returns user information for the specified user id.
    /// </summary>
    Task<UserDto> GetMeAsync(Guid id);
}