using System.Security.Claims;
using Friendium.Api.DTOs.Request;
using Friendium.Api.DTOs.Response;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Friendium.Api.Exceptions;

namespace Friendium.Api.Services.Implementations;

/// <summary>
/// Service implementation for authentication operations.
/// Handles user login, registration, password hashing, and cookie-based authentication.
/// </summary>
public sealed class AuthService(IUserRepository repo, IUserProfileRepository profileRepo, IHttpContextAccessor httpContextAccessor, IPasswordHasher<User> hasher) : IAuthService
{
    public async Task<UserDto> LoginAsync(LoginDto dto)
    {
        // Checks if user with the given email exists.
        var existingUser = await repo.GetByEmailAsync(dto.Email);
        if (existingUser == null)
            throw new AuthenticationFailedException("Invalid credentials");

        // Checks if password is incorrect.
        var result = hasher.VerifyHashedPassword(existingUser, existingUser.PasswordHash, dto.Password);
        if (result is not (PasswordVerificationResult.Success or PasswordVerificationResult.SuccessRehashNeeded))
            throw new AuthenticationFailedException("Invalid credentials");

        // Checks if password needs rehashing.
        if (result == PasswordVerificationResult.SuccessRehashNeeded)
        {
            // Rehashes the password.
            existingUser.PasswordHash = hasher.HashPassword(existingUser, dto.Password);
            await repo.UpdateAsync(existingUser);

        }

        // Creates a list containing the user claims.
        // These will be sent in the cookie, so the client side knows, who is the current user.
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString()),
            new Claim(ClaimTypes.Name, existingUser.Firstname + " " + existingUser.Lastname),
            new Claim(ClaimTypes.Email, existingUser.Email),
        };

        // Creates a ClaimsIdentity, which contains the user claims and the authentication scheme.
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        // Sets up the authentication properties.
        // It's uses default settings currently, but we can set properties like IsPersistent or ExpiresUtc, etc. 
        var authProperties = new AuthenticationProperties();

        // Logs in the user through HttpContext.
        // SignInAsync creates the cookie in the browser.
        if (httpContextAccessor.HttpContext == null)
            throw new InvalidOperationException("HttpContext is not available for signing in");

        await httpContextAccessor.HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        // Returns a UserDto, which doesn't contain sensitive data.
        return new UserDto(existingUser.Id, existingUser.Firstname, existingUser.Lastname, existingUser.Email);
    }


    public async Task<UserDto> RegisterAsync(RegisterDto dto)
    {
        // Checks if user with the given email exists already
        var existingUser = await repo.GetByEmailAsync(dto.Email);
        if (existingUser != null)
            throw new ConflictException("Email already in use");

        // Creates an instance of the user model based on the data transfer object
        var newUser = new User
        {
            Firstname = dto.Firstname,
            Lastname = dto.Lastname,
            Email = dto.Email,
        };

        // Hashes the password and passes it to the user object
        newUser.PasswordHash = hasher.HashPassword(newUser, dto.Password);

        // Saves the user to the database
        await repo.AddAsync(newUser);

        if (!DateOnly.TryParse(dto.DateOfBirth, out var parsedDob))
            throw new ValidationException("DateOfBirth is not in a valid format");

        var newProfile = new UserProfile
        {
            UserId = newUser.Id,
            Gender = dto.Gender,
            DateOfBirth = parsedDob,
        };

        Console.WriteLine(newProfile);
        await profileRepo.AddAsync(newProfile);


        // Creates a list containing the user claims.
        // These will be sent in the cookie, so the client side knows, who is the current user.
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, newUser.Id.ToString()),
            new Claim(ClaimTypes.Name, newUser.Firstname + " " + newUser.Lastname),
            new Claim(ClaimTypes.Email, newUser.Email),
        };

        // Creates a ClaimsIdentity, which contains the user claims and the authentication scheme.
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        // Sets up the authentication properties.
        // It's uses default settings currently, but we can set properties like IsPersistent or ExpiresUtc, etc. 
        var authProperties = new AuthenticationProperties();

        // Logs in the user through HttpContext.
        // SignInAsync creates the cookie in the browser.
        if (httpContextAccessor.HttpContext == null)
            throw new InvalidOperationException("HttpContext is not available for signing in");

        await httpContextAccessor.HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
        // Returns a user dto, which doesn't contain sensitive data.
        return new UserDto(newUser.Id, newUser.Firstname, newUser.Lastname, newUser.Email);
    }

    public async Task<UserDto> GetMeAsync(Guid id)
    {
        var user = await repo.GetByIdAsync(id);
        return user == null ?
            throw new ResourceNotFoundException("User not found") :
            new UserDto(user.Id, user.Firstname, user.Lastname, user.Email);
    }
}