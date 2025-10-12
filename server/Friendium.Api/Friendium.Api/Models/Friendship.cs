namespace Friendium.Api.Models;

public class Friendship
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid FriendId { get; set; }
    public DateTime Created { get; set; }
    
    public User? User { get; set; }
    public User? Friend { get; set; }
}