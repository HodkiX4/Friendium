using System.ComponentModel.DataAnnotations;

namespace Friendium.Api.DTOs.Request;

/// <summary>
/// DTO for updating user information (name, email, password)
/// </summary>
public record UpdateUserDto
{
    [StringLength(50, ErrorMessage = "Firstname cannot exceed 50 characters")]
    public string? Firstname { get; init; }

    [StringLength(50, ErrorMessage = "Lastname cannot exceed 50 characters")]
    public string? Lastname { get; init; }

    [EmailAddress(ErrorMessage = "Email is invalid")]
    public string? Email { get; init; }

    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    [RegularExpression("^(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&]).+$",
        ErrorMessage = "Password must contain at least one uppercase letter, one number, and one special character")]
    public string? NewPassword { get; init; }

    [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
    public string? ConfirmNewPassword { get; init; }
}
