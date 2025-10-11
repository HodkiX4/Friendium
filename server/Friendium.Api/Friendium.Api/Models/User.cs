using System.ComponentModel.DataAnnotations;

namespace Friendium.Api.Models;

public class User
{
    public Guid Id { get; }  = Guid.NewGuid();
    
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(200)]
    public string PasswordHash { get; set; } = string.Empty;
}