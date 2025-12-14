using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Friendium.Api.Models;

namespace Friendium.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User <-> UserProfile : one-to-one
        modelBuilder.Entity<UserProfile>()
            .HasOne(p => p.User)
            .WithOne(u => u.Profile)
            .HasForeignKey<UserProfile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // User <-> UserActivity : one-to-one
        modelBuilder.Entity<UserActivity>()
            .HasOne(a => a.User)
            .WithOne(u => u.Activity)
            .HasForeignKey<UserActivity>(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // FriendRequest: Sender and Receiver (many requests per user)
        modelBuilder.Entity<FriendRequest>()
            .HasOne(fr => fr.Sender)
            .WithMany(u => u.SentRequests)
            .HasForeignKey(fr => fr.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<FriendRequest>()
            .HasOne(fr => fr.Receiver)
            .WithMany(u => u.ReceivedRequests)
            .HasForeignKey(fr => fr.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

        // Friendship: user owns many friendships; friend is another user
        modelBuilder.Entity<Friendship>()
            .HasOne(f => f.User)
            .WithMany(u => u.Friends)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Friendship>()
            .HasOne(f => f.Friend)
            .WithMany()
            .HasForeignKey(f => f.FriendId)
            .OnDelete(DeleteBehavior.Restrict);

        // Message -> User and Message -> Chat
        modelBuilder.Entity<Message>()
            .HasOne(m => m.User)
            .WithMany(u => u.Messages)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.Chat)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        // Chat.UserIds and UserProfile.Interests are collections of simple types.
        // Convert them to JSON strings for storage.
        // Use static helper methods to avoid expression tree issues with optional args
        var guidListConverter = new ValueConverter<ICollection<Guid>, string>(
            v => SerializeGuids(v),
            v => DeserializeGuids(v));

        var stringListConverter = new ValueConverter<ICollection<string>, string>(
            v => SerializeStrings(v),
            v => DeserializeStrings(v));

        modelBuilder.Entity<Chat>()
            .Property(c => c.UserIds)
            .HasConversion(guidListConverter);

        modelBuilder.Entity<UserProfile>()
            .Property(p => p.Interests)
            .HasConversion(stringListConverter);
    }

    // Helper methods used by value-converter expressions. Kept static so they can be
    // referenced from expression trees without bringing optional-argument overloads in.
    private static string SerializeGuids(ICollection<Guid> guids)
        => JsonSerializer.Serialize(guids);

    private static ICollection<Guid> DeserializeGuids(string json)
        => JsonSerializer.Deserialize<ICollection<Guid>>(json) ?? new List<Guid>();

    private static string SerializeStrings(ICollection<string> values)
        => JsonSerializer.Serialize(values);

    private static ICollection<string> DeserializeStrings(string json)
        => JsonSerializer.Deserialize<ICollection<string>>(json) ?? new List<string>();
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserProfile> UserProfiles { get; set; } = null!;
    public DbSet<UserActivity> UserActivities { get; set; } = null!;
    public DbSet<FriendRequest> FriendRequests { get; set; } = null!;
    public DbSet<Friendship> Friendships { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<Chat> Chats { get; set; } = null!;
}