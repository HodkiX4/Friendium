using Friendium.Api.DTOs;
using Friendium.Api.DTOs.Response;
using Friendium.Api.Exceptions;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;

namespace Friendium.Api.Services.Implementations;

/// <summary>
/// Service implementation for user fetching operations.
/// Handles the fetching of all users, and the fetching of a single user.
/// </summary>
public sealed class UserService(IUserRepository repo) : IUserService
{
    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        var users = await repo.GetAllAsync();
        return users.Select(u => new UserDto(u.Id.ToString(), u.Firstname, u.Lastname, u.Email));
    }

    public async Task<UserDto?> GetUserById(Guid userId)
    {
        var user = await repo.GetByIdAsync(userId);
        if (user == null)
            throw new ResourceNotFoundException("User not found");
        return new UserDto(user.Id.ToString(), user.Firstname, user.Lastname, user.Email);
    }

    public async Task<UserDto?> UpdateUserName(Guid userId, UserDto updatedUser)
    {
        var existingUser = await repo.GetByIdAsync(userId);
        if (existingUser == null)
            throw new ResourceNotFoundException("User not found");

        existingUser.Firstname = updatedUser.Firstname;
        existingUser.Lastname = updatedUser.Lastname;

        await repo.UpdateAsync(existingUser);

        return new UserDto(existingUser.Id.ToString(), existingUser.Firstname, existingUser.Lastname, existingUser.Email);
    }

    public async Task DeleteUser(Guid userId)
    {
        var existingUser = await repo.GetByIdAsync(userId);
        if (existingUser == null)
            throw new ResourceNotFoundException("User not found");

        await repo.RemoveAsync(existingUser);
    }
}