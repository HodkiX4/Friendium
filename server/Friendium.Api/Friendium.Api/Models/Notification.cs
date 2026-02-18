namespace Friendium.Api.Models;

/// <summary>
/// Represents a notification recived by a user.
/// It has text content
/// </summary>
public class Notification
{
    /// <summary>
    /// The unique identifier of the notification.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier of the user who recieves the notification.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// The unique identifier of the reference entity related to the notification.
    /// </summary>
    public Guid ReferenceId { get; init; }

    /// <summary>
    /// The text content of the notification.
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Indicates whether the notification has been read.
    /// </summary>
    public bool IsRead { get; set; } = false;

    /// <summary>
    /// The UTC timestamp when the notification was created.
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// Navigation property representing the user associated with this notification.
    /// </summary>
    public User? User { get; init; }
}