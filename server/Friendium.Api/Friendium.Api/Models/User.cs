using System.ComponentModel.DataAnnotations;

namespace Friendium.Api.Models;

public class User
{
    public Guid Id { get; init; }  = Guid.NewGuid();
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(80)]
    public string Email { get; init; } = string.Empty;
    [MaxLength(200)]
    public string PasswordHash { get; set; } = string.Empty;
    
    public UserProfile? Profile { get; init; }
    public UserActivity? Activity { get; init; }
    
    public ICollection<Friendship> Friends { get; set; } = [];
    public ICollection<FriendRequest> SentRequests { get; set; } = [];
    public ICollection<FriendRequest> ReceivedRequests { get; set; } = [];
}