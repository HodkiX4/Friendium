namespace Friendium.Api.Models;

public class FriendRequest
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid SenderId { get; init; }
    public Guid ReceiverId { get; init; }
    public DateTime SentAt { get; init; } = DateTime.UtcNow;
    public bool IsAccepted { get; set; } = false;
    
    public User? Sender { get; init; }
    public User? Receiver { get; init; }
}