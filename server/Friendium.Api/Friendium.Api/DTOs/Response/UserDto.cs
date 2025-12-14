namespace Friendium.Api.DTOs.Response;

public record UserDto(
    string Id,
    string Firstname,
    string Lastname,
    string Email
);