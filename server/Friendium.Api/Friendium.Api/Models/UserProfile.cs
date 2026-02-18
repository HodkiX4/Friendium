using System.ComponentModel.DataAnnotations;
using Friendium.Api.Enums;

namespace Friendium.Api.Models;

/// <summary>
/// Represents a user's extended profile information, including
/// personal details, location, preferences, and visibility settings.
/// </summary>
public sealed class UserProfile
{
    /// <summary>
    /// The unique identifier of the user profile.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier of the user to whom the profile belongs.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// The URL of the user's avatar image.  
    /// Limited to 255 characters.
    /// </summary>
    [MaxLength(255)]
    public string AvatarUrl { get; set; } = string.Empty;

    /// <summary>
    /// The biography or short description written by the user.  
    /// Limited to 500 characters.
    /// </summary>
    [MaxLength(500)]
    public string Bio { get; set; } = string.Empty;

    /// <summary>
    /// The date of birth of the user.
    /// </summary>
    public DateOnly DateOfBirth { get; set; }

    /// <summary>
    /// The gender of the user, represented by the <see cref="Gender"/> enum.
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// The list of personal interests or hobbies associated with the user.
    /// </summary>
    public ICollection<string> Interests { get; set; } = new List<string>();

    /// <summary>
    /// The city where the user currently resides.  
    /// Limited to 100 characters.
    /// </summary>
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// The country where the user currently resides.  
    /// Limited to 100 characters.
    /// </summary>
    [MaxLength(100)]
    public string Country { get; set; } = string.Empty;

    /// <summary>
    /// The geographical latitude of the user's location.
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// The geographical longitude of the user's location.
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Indicates whether the user's profile is publicly visible.
    /// Defaults to <c>true</c>.
    /// </summary>
    public bool IsVisible { get; set; } = true;

    /// <summary>
    /// Navigation property representing the user associated with this profile.
    /// </summary>
    public User? User { get; set; }
}
