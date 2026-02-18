using System.ComponentModel.DataAnnotations;

namespace Friendium.Api.Models;

/// <summary>
/// Represents an application user, including personal information,
/// authentication details, and relational data such as friends and requests.
/// </summary>
public sealed class User
{
    /// <summary>
    /// The unique identifier of the user.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// The firstname of the user.  
    /// Limited to 50 characters.
    /// </summary>
    [MaxLength(50)]
    public string Firstname { get; set; } = string.Empty;

    /// <summary>
    /// The lastname of the user.  
    /// Limited to 50 characters.
    /// </summary>
    [MaxLength(50)]
    public string Lastname { get; set; } = string.Empty;

    /// <summary>
    /// The user's email address, which is used for authentication.  
    /// Limited to 80 characters.
    /// </summary>
    [MaxLength(80)]
    public string Email { get; init; } = string.Empty;

    /// <summary>
    /// The hashed password for user authentication.  
    /// Limited to 200 characters.
    /// </summary>
    [MaxLength(200)]
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// The UTC timestamp when the user account was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// The user's extended profile information (bio, preferences, gender, etc.).
    /// </summary>
    public UserProfile? Profile { get; set; }

    /// <summary>
    /// The user's activity data (last seen, online status).
    /// </summary>
    public UserActivity? Activity { get; init; }

    /// <summary>
    /// A collection of the user's friendships (approved friend relationships).
    /// </summary>
    public ICollection<Friendship> Friends { get; set; } = new List<Friendship>();

    /// <summary>
    /// A collection of friend requests sent by the user.
    /// </summary>
    public ICollection<FriendRequest> SentRequests { get; set; } = new List<FriendRequest>();

    /// <summary>
    /// A collection of friend requests received by the user.
    /// </summary>
    public ICollection<FriendRequest> ReceivedRequests { get; set; } = new List<FriendRequest>();

    /// <summary>
    /// Messages authored by the user.
    /// </summary>
    public ICollection<Message> Messages { get; set; } = new List<Message>();

    /// <summary>
    /// Notifications received by the user.
    /// </summary>
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}