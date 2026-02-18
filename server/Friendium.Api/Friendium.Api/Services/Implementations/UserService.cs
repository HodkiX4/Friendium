using Friendium.Api.DTOs;
using Friendium.Api.DTOs.Request;
using Friendium.Api.DTOs.Response;
using Friendium.Api.Exceptions;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Friendium.Api.Services.Implementations;

/// <summary>
/// Service implementation for user fetching operations.
/// Handles the fetching of all users, and the fetching of a single user.
/// </summary>
public sealed class UserService(IUserRepository repo, IPasswordHasher<User> hasher) : IUserService
{
    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        var users = await repo.GetAllAsync();
        return users.Select(u => new UserDto(u.Id, u.Firstname, u.Lastname, u.Email));
    }

    public async Task<UserDto?> GetUserById(Guid userId)
    {
        var user = await repo.GetByIdAsync(userId);
        if (user == null)
            throw new ResourceNotFoundException("User not found");
        return new UserDto(user.Id, user.Firstname, user.Lastname, user.Email);
    }

    public async Task<UserDto?> UpdateUserName(Guid userId, UserDto updatedUser)
    {
        var existingUser = await repo.GetByIdAsync(userId);
        if (existingUser == null)
            throw new ResourceNotFoundException("User not found");

        existingUser.Firstname = updatedUser.Firstname;
        existingUser.Lastname = updatedUser.Lastname;

        await repo.UpdateAsync(existingUser);

        return new UserDto(existingUser.Id, existingUser.Firstname, existingUser.Lastname, existingUser.Email);
    }

    public async Task DeleteUser(Guid userId)
    {
        var existingUser = await repo.GetByIdAsync(userId);
        if (existingUser == null)
            throw new ResourceNotFoundException("User not found");

        await repo.RemoveAsync(existingUser);
    }

    public async Task<UserDto?> UpdateUser(Guid userId, UpdateUserDto dto)
    {
        var existingUser = await repo.GetByIdAsync(userId);
        if (existingUser == null)
            throw new ResourceNotFoundException("User not found");

        if (!string.IsNullOrWhiteSpace(dto.Firstname))
            existingUser.Firstname = dto.Firstname;

        if (!string.IsNullOrWhiteSpace(dto.Lastname))
            existingUser.Lastname = dto.Lastname;

        if (!string.IsNullOrWhiteSpace(dto.NewPassword))
        {
            existingUser.PasswordHash = hasher.HashPassword(existingUser, dto.NewPassword);
        }

        await repo.UpdateAsync(existingUser);

        return new UserDto(existingUser.Id, existingUser.Firstname, existingUser.Lastname, existingUser.Email);
    }
}