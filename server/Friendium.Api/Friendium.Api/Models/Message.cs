using System.ComponentModel.DataAnnotations;

namespace Friendium.Api.Models;

/// <summary>
/// Represents a message sent by a user inside a chat room.
/// Contains the message text, timestamps and navigation links to the author and chat.
/// </summary>
public class Message
{
    /// <summary>
    /// The unique identifier of the message.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier of the user who authored the message.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// The unique identifier of the chat that contains this message.
    /// </summary>
    public Guid ChatId { get; init; }

    /// <summary>
    /// The text content of the message. Limited to 500 characters.
    /// </summary>
    [MaxLength(500)]
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// UTC timestamp when the message was created.
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// UTC timestamp of the last update to the message, if any.
    /// </summary>
    public DateTime? UpdatedAt { get; set; } = null;

    /// <summary>
    /// Navigation to the authoring user.
    /// </summary>
    public User? User { get; init; }

    /// <summary>
    /// Navigation to the containing chat.
    /// </summary>
    public Chat? Chat { get; init; }
}