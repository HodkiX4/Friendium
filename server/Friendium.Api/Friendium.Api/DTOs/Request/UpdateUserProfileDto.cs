using System.ComponentModel.DataAnnotations;
using Friendium.Api.Enums;

namespace Friendium.Api.DTOs.Request;

/// <summary>
/// 
/// </summary>
public record UpdateUserProfileDto
{
    [MaxLength(255)]
    public string? AvatarUrl { get; init; }
    
    [MaxLength(500)]
    public string? Bio { get; init; }
    
    public DateOnly? DateOfBirth { get; init; }
    public Gender? Gender { get; init; }
    public List<string>? Interests { get; init; }
    
    [MaxLength(100)]
    public string? City { get; init; }
    
    [MaxLength(100)]
    public string? Country { get; set; }
    public bool? IsVisible { get; init; }
};