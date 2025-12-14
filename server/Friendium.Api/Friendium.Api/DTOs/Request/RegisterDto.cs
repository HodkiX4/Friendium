using System.ComponentModel.DataAnnotations;
using Friendium.Api.Enums;

namespace Friendium.Api.DTOs.Request;

public record RegisterDto
{
    [Required(ErrorMessage = "Firstname is required")]
    [StringLength(50, ErrorMessage = "Firstname cannot exceed 50 characters")]
    public required string Firstname { get; set; }
    
    [Required(ErrorMessage = "Lastname is required")]
    [StringLength(50, ErrorMessage = "Lastname cannot exceed 50 characters")]
    public required string Lastname { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    public required string Email { get; set; }
    
    [Required(ErrorMessage = "Gender is required")]
    public required Gender Gender {  get; set; }
    
    [Required(ErrorMessage = "Date of birth is required")]
    public required string DateOfBirth { get; init; }
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    [RegularExpression("^(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&]).+$",
        ErrorMessage = "Password must contain at least one uppercase letter, one number, and one special character")]
    public required string Password { get; set; }
    
    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
    public required string ConfirmPassword { get; set; }
    
}