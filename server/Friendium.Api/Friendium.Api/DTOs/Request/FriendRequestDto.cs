namespace Friendium.Api.DTOs.Request;

public record FriendRequestDto (
    Guid Id,
    Guid SenderId,
    Guid ReceiverId,  
    DateTime SentAt,  
    bool IsAccepted
);