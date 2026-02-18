namespace Friendium.Api.Models;

/// <summary>
/// Represents a chat room between users. Contains the list of participant user ids
/// and the messages sent in the chat.
/// </summary>
public class Chat
{
    /// <summary>
    /// The unique identifier of the chat.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// The collection of user identifiers participating in this chat.
    /// Stored as JSON by EF Core (configured in AppDbContext).
    /// </summary>
    public ICollection<Guid> UserIds { get; set; } = new List<Guid>();

    /// <summary>
    /// The messages that belong to this chat.
    /// </summary>
    public ICollection<Message> Messages { get; set; } = new List<Message>();

    /// <summary>
    /// The UTC timestamp when the chat was created.
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}