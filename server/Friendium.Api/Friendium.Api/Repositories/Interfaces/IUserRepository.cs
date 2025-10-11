using Friendium.Api.Models;

namespace Friendium.Api.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User?> GetUserById(int id);
    Task<User?> GetUserByEmail(string email);
    Task CreateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(User user);
}