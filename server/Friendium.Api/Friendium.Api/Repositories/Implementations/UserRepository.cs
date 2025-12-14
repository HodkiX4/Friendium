using Friendium.Api.Data;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Friendium.Api.Repositories.Implementations;

/// <summary>
/// Repository implementation for user data storage.
/// Provides methods to query and modify users in the database.
/// </summary>
public sealed class UserRepository(AppDbContext context) : IUserRepository
{

    public async Task<IEnumerable<User>> GetAllAsync()
        => await context.Users.AsNoTracking().ToListAsync();

    public async Task<User?> GetByIdAsync(Guid id)
        => await context.Users.FindAsync(id);

    public async Task<User?> GetByEmailAsync(string email)
        => await context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task AddAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User updatedUser)
    {
        context.Users.Update(updatedUser);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(User user)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}