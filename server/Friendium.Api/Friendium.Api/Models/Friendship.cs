namespace Friendium.Api.Models;

public class Friendship
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid UserId { get; init; }
    public Guid FriendId { get; init; }
    public DateTime Created { get; init; }
    
    public User? User { get; init; }
    public User? Friend { get; init; }
}