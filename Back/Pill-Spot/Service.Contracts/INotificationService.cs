using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface INotificationService
    {
        // Core notification operations
        Task<PagedList<NotificationDto>> GetUserNotificationsAsync(string userId, NotificationRequestParameters parameters, bool trackChanges);
        Task<PagedList<NotificationDto>> GetNotificationsAsync(NotificationRequestParameters parameters, bool trackChanges);
        Task<NotificationDto> GetNotificationByIdAsync(Guid id, bool trackChanges);
        Task<NotificationDto> CreateNotificationAsync(NotificationForCreationDto notificationDto);
        Task DeleteNotificationAsync(Guid notificationId, bool trackChanges);
        
        // Read status operations
        Task MarkNotificationAsReadAsync(Guid notificationId);
        Task MarkAllNotificationsAsReadAsync(string userId);
        Task<int> GetUnreadNotificationCountAsync(string userId);
        Task<IEnumerable<NotificationDto>> GetUnreadNotificationsAsync(string userId);

        // Real-time notification operations
        Task SendNotificationAsync(string userId, string title, string message, NotificationType type, string? data = null);
        Task SendBulkNotificationAsync(IEnumerable<string> userIds, string title, string message, NotificationType type, string? data = null);

        // Business event notifications
        Task SendPrescriptionExpiryNotificationAsync(string userId, Guid prescriptionId, DateTime expiryDate);
        Task SendPaymentConfirmationNotificationAsync(string userId, Guid orderId, decimal amount);
        Task SendDeliveryStatusNotificationAsync(string userId, Guid orderId, string status);
        Task SendPriceChangeNotificationAsync(string userId, Guid productId, string productName, decimal oldPrice, decimal newPrice);
        Task SendPromotionNotificationAsync(string userId, string promotionId, string promotionName, DateTime expiryDate);
        Task SendProductInfoNotificationAsync(string userId, string productId, string productName, string infoType, string message);

        // Product-specific notifications
        Task SendProductSpecificNotificationAsync(string userId, string productId, string productName, string infoType);

        // Grouped notification methods
        Task SendGroupedProductNotificationsAsync(string userId, IEnumerable<(string productId, string productName, string infoType)> updates);
        Task SendGroupedNotificationsAsync(string userId, string groupType, IEnumerable<(string title, string message, string type, string? data)> notifications);
        Task SendDailyProductUpdatesAsync(string userId, IEnumerable<(string productId, string productName, string infoType)> dailyUpdates);
        Task SendWeeklySummaryAsync(string userId, IEnumerable<(string title, string message, string type, string? data)> weeklyUpdates);

        // Additional notification types
        Task MarkAsNotifiedAsync(Guid notificationId, bool trackChanges);
    }
}
