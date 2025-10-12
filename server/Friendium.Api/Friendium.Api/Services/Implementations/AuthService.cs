using Friendium.Api.DTOs;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Friendium.Api.Services.Implementations;

public class AuthService(IUserRepository repo, PasswordHasher<User> hasher) : IAuthService
{
    public async Task<User?> ValidateCredentialsAsync(LoginDto dto)
    {
        var user = await repo.GetByEmailAsync(dto.Email);
        if (user == null) return null;
        
        var result = hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if (result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded)
        {
            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.PasswordHash = hasher.HashPassword(user, dto.Password);
                await repo.UpdateAsync(user);
            }

            return user;
        }

        return null;
    }


    public async Task<UserDto> RegisterAsync(RegisterDto dto)
    {
        var existingUser = await repo.GetByEmailAsync(dto.Email);
        if (existingUser != null)
            throw new UnauthorizedAccessException("Email already in use");

        var newUser = new User
        {
            Name = dto.Name,
            Email = dto.Email,
        };
        newUser.PasswordHash = hasher.HashPassword(newUser, dto.Password);
        await repo.AddAsync(newUser);
        return new UserDto(newUser.Id.ToString(), newUser.Name, newUser.Email);
    }
}