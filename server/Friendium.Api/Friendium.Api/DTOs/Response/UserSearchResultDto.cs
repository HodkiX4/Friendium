using Friendium.Api.Enums;

namespace Friendium.Api.DTOs.Response;

public record UserSearchResultDto(
    Guid Id,
    string DisplayName,
    string? AvatarUrl,
    string? ShortBio,
    IEnumerable<string>? Interests,
    string? City,
    string? Country,
    bool IsVisible,
    Gender Gender
);
