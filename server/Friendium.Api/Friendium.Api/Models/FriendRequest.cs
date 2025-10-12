namespace Friendium.Api.Models;

public class FriendRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public bool IsAccepted { get; set; } = false;
    
    public User? Sender { get; set; }
    public User? Receiver { get; set; }
}