using System.ComponentModel.DataAnnotations;

namespace Friendium.Api.Models;

public class User
{
    public Guid Id { get; set; }  = Guid.NewGuid();
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(80)]
    public string Email { get; set; } = string.Empty;
    [MaxLength(200)]
    public string PasswordHash { get; set; } = string.Empty;
    
    public UserProfile? Profile { get; set; }
    public UserActivity? Activity { get; set; }
    
    public ICollection<Friendship> Friends { get; set; } = new List<Friendship>();
    public ICollection<FriendRequest> SentRequests { get; set; } = new List<FriendRequest>();
    public ICollection<FriendRequest> ReceivedRequests { get; set; } = new List<FriendRequest>();
}