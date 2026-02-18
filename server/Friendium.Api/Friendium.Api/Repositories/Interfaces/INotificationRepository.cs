using Friendium.Api.Models;

namespace Friendium.Api.Repositories.Interfaces;

/// <summary>
/// Repository interface for notification data operations.
/// </summary>
public interface INotificationRepository
{
    /// <summary>
    /// Retrieves all notifications.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>A list of notifications.</returns>
    Task<IEnumerable<Notification>> GetNotificationsAsync(Guid userId);

    /// <summary>
    /// Retrieves a notification by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the notification.</param>
    /// <returns>The notification, if it exists, otherwise null.</returns>
    Task<Notification> GetNotificationByIdAsync(int id);

    /// <summary>
    /// Creates a new notification.
    /// </summary>
    /// <param name="notification">The notification to create.</param>
    Task CreateNotificationAsync(Notification notification);

    /// <summary>
    /// Updates an existing notification.
    /// </summary>
    /// <param name="notification">The notification to update.</param>
    Task UpdateNotificationAsync(Notification notification);

    /// <summary>
    /// Deletes a notification by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the notification to delete.</param>
    Task DeleteNotificationAsync(int id);
}