using Friendium.Api.Data;
using Friendium.Api.Models;
using Friendium.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Friendium.Api.Repositories.Implementations;

public class NotificationRepository(AppDbContext context) : INotificationRepository
{
    public async Task<IEnumerable<Notification>> GetNotificationsAsync(Guid userId)
    {
        return await context.Notifications.Where(n => n.UserId == userId).ToListAsync();
    }

    public async Task<Notification> GetNotificationByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task CreateNotificationAsync(Notification notification)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateNotificationAsync(Notification notification)
    {
        throw new NotImplementedException();
    }

    public Task DeleteNotificationAsync(int id)
    {
        throw new NotImplementedException();
    }
}