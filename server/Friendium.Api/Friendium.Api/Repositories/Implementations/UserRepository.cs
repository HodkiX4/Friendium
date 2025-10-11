using Friendium.Api.Data;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Friendium.Api.Repositories.Implementations;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAllUsers()
        => await context.Users.ToListAsync();

    public async Task<User?> GetUserById(int id)
        => await context.Users.FindAsync(id);

    public async Task<User?> GetUserByEmail(string email)
        => await context.Users.FirstOrDefaultAsync(u => u.Email == email);
    public async Task CreateUser(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateUser(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteUser(User user)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}