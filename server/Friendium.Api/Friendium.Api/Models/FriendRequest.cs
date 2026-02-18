namespace Friendium.Api.Models;

/// <summary>
/// Represents a friend request sent from one user to another.
/// Includes the request status and related metadata.
/// </summary>
public class FriendRequest
{
    /// <summary>
    /// The unique identifier of the friend request.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier of the user who sent the request.
    /// </summary>
    public Guid SenderId { get; init; }

    /// <summary>
    /// The unique identifier of the user who received the request.
    /// </summary>
    public Guid ReceiverId { get; init; }

    /// <summary>
    /// The UTC timestamp of when the request was sent.
    /// </summary>
    public DateTime SentAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// Indicates whether the request has been accepted.
    /// Defaults to <c>false</c>.
    /// </summary>
    public bool IsAccepted { get; set; } = false;

    /// <summary>
    /// Navigation property for the user who sent the request.
    /// </summary>
    public User? Sender { get; init; }

    /// <summary>
    /// Navigation property for the user who received the request.
    /// </summary>
    public User? Receiver { get; init; }
}