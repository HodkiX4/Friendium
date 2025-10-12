using Friendium.Api.Enums;

namespace Friendium.Api.DTOs;

public record UserProfileDto(
    Guid UserId,
    string AvatarUrl,
    string Bio,
    DateOnly DateOfBirth,
    Gender Gender,
    IEnumerable<string> Interests,
    string City,
    string Country,
    double Latitude,
    double Longitude,
    bool IsVisible
);