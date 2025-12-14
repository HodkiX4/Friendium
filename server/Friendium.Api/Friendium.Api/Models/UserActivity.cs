namespace Friendium.Api.Models;

/// <summary>
/// Represents real-time activity data for a user,
/// including online status and last seen timestamp.
/// </summary>
public class UserActivity
{
    /// <summary>
    /// The unique identifier of the user activity record.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier of the user associated with this activity record.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// The UTC timestamp of the user's last recorded activity.
    /// </summary>
    public DateTime LastSeen { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Indicates whether the user is currently online.
    /// Defaults to <c>true</c>.
    /// </summary>
    public bool IsOnline { get; set; } = true;

    /// <summary>
    /// Navigation property for the related user.
    /// </summary>
    public User? User { get; init; }
}