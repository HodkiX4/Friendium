namespace Friendium.Api.Models;

/// <summary>
/// Represents a mutual friendship relationship between two users.
/// Each record indicates that both users are connected as friends.
/// </summary>
public class Friendship
{
    /// <summary>
    /// The unique identifier of the friendship record.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier of the user who owns this friendship entry.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// The unique identifier of the user's friend.
    /// </summary>
    public Guid FriendId { get; init; }

    /// <summary>
    /// Indicates whether this friendship is blocked by the user.
    /// Defaults to <c>false</c>.
    /// </summary>
    public bool IsBlocked { get; set; } = false;
    /// <summary>
    /// The UTC timestamp of when the friendship was created.
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// Navigation property representing the user associated with this friendship.
    /// </summary>
    public User? User { get; init; }

    /// <summary>
    /// Navigation property representing the friend in this friendship.
    /// </summary>
    public User? Friend { get; init; }
}