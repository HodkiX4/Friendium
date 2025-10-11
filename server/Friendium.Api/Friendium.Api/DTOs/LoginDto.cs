using System.ComponentModel.DataAnnotations;

namespace Friendium.Api.DTOs;

public record LoginDto(
    [Required(ErrorMessage = "Email is required")] string Email,
    [Required(ErrorMessage = "Password is required")] string Password
);