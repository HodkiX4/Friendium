using Friendium.Api.Models;

namespace Friendium.Api.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    Task<User?> GetUserById(Guid userId);
}