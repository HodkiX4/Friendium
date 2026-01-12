namespace Friendium.Api.DTOs.Response;

public record MessageDto(
    Guid Id,
    Guid ChatId,
    Guid UserId,
    string Text,
    DateTime? UpdatedAt
);