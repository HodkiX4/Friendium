using Friendium.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Friendium.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<User> Users { get; set; } = null!;
}