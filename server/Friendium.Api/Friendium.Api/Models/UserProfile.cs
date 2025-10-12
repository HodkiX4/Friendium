using System.ComponentModel.DataAnnotations;
using Friendium.Api.Enums;

namespace Friendium.Api.Models;

public class UserProfile
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    
    [MaxLength(255)]
    public string AvatarUrl { get; set; }  = string.Empty;
    [MaxLength(500)]
    public string Bio { get; set; } = string.Empty;
    
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public ICollection<string> Interests { get; set; } = [];
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Country { get; set; } = string.Empty;
    
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool IsVisible { get; set; } = true;
    
    public User? User { get; set; }
}