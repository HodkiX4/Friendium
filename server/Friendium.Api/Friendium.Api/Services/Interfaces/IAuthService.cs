using Friendium.Api.DTOs;
using Friendium.Api.Models;

namespace Friendium.Api.Services.Interfaces;

public interface IAuthService
{
    Task<User?> ValidateCredentialsAsync(LoginDto dto);
    Task<UserDto> RegisterAsync(RegisterDto dto);
}