using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Friendium.Api.Services.Interfaces;

namespace Friendium.Api.Services.Implementations;

public class UserService(IUserRepository repo) : IUserService
{
    public async Task<IEnumerable<User>> GetUsers()
        => await repo.GetAllAsync();

    public async Task<User?> GetUserById(Guid userId)
        => await repo.GetByIdAsync(userId);
}