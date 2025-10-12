namespace Friendium.Api.Models;

public class UserActivity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid UserId { get; init; }
    
    public DateTime LastSeen { get; set; } = DateTime.UtcNow;
    public bool IsOnline { get; set; } = true;
}