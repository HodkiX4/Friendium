namespace Friendium.Api.DTOs;

public record FriendRequestDto (
    Guid Id,
    Guid SenderId,
    Guid ReceiverId,  
    DateTime SentAt,  
    bool IsAccepted
);