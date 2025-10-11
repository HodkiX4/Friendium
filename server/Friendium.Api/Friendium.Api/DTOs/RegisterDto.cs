using System.ComponentModel.DataAnnotations;

namespace Friendium.Api.DTOs;

public record RegisterDto(
    [
        Required(ErrorMessage = "Name is required"),
        StringLength(50, ErrorMessage = "Name cannot exceed 50 characters"),
    ] string Name,
    [
        Required(ErrorMessage = "Email is required"),
        EmailAddress(ErrorMessage = "Email is invalid")
    ] string Email,
    [
        Required(ErrorMessage = "Password is required"),
        RegularExpression("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$", ErrorMessage = "Invalid Password")
    ] string Password
);