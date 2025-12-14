using System.ComponentModel.DataAnnotations;

namespace Friendium.Api.DTOs.Request;

/// <summary>
/// A data transfer object that carries the login credentials.
/// </summary>
/// <param name="Email">The email given by the user.</param>
/// <param name="Password">The password given by the user.</param>
public record LoginDto(
    [Required(ErrorMessage = "Email is required")] string Email,
    [Required(ErrorMessage = "Password is required")] string Password
);