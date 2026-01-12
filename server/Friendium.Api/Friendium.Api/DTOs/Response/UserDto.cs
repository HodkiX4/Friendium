namespace Friendium.Api.DTOs.Response;

public record UserDto(
    Guid Id,
    string Firstname,
    string Lastname,
    string Email
);