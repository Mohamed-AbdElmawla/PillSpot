using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Notifications;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service
{
    public class NotificationService : INotificationService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMediator _mediator;
        private readonly IRealTimeNotificationService _realTimeNotificationService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public NotificationService(
            IRepositoryManager repository,
            IMediator mediator,
            IRealTimeNotificationService realTimeNotificationService,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _repository = repository;
            _mediator = mediator;
            _realTimeNotificationService = realTimeNotificationService;
            _mapper = mapper;
            _userManager = userManager;
        }

        // Helper method to get user ID from username
        private async Task<string> GetUserIdFromUsernameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                throw new UserNotFoundException(username);
            return user.Id;
        }

        // Helper method to get username from user ID
        private async Task<string> GetUsernameFromUserIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);
            return user.UserName;
        }

        public async Task<PagedList<NotificationDto>> GetUserNotificationsAsync(
            string userId, 
            NotificationRequestParameters parameters, 
            bool trackChanges)
        {
            var pagedNotifications = await _repository.NotificationRepository
                .GetUserNotificationsAsync(userId, parameters, trackChanges);

            var notificationDtos = _mapper.Map<IEnumerable<NotificationDto>>(pagedNotifications).ToList();
            return new PagedList<NotificationDto>(
                notificationDtos,
                pagedNotifications.MetaData.TotalCount,
                pagedNotifications.MetaData.CurrentPage,
                pagedNotifications.MetaData.PageSize
            );
        }

        public async Task<PagedList<NotificationDto>> GetUserNotificationsByUsernameAsync(
            string username, 
            NotificationRequestParameters parameters, 
            bool trackChanges)
        {
            var userId = await GetUserIdFromUsernameAsync(username);
            return await GetUserNotificationsAsync(userId, parameters, trackChanges);
        }

        public async Task<NotificationDto> GetNotificationByIdAsync(Guid id, bool trackChanges)
        {
            var notification = await _repository.NotificationRepository.GetNotificationByIdAsync(id, trackChanges);
            if (notification == null)
                throw new NotificationNotFoundException(id);

            return _mapper.Map<NotificationDto>(notification);
        }

        public async Task<NotificationDto> CreateNotificationAsync(NotificationForCreationDto notificationDto)
        {
            var notification = _mapper.Map<Notification>(notificationDto);
            notification.NotificationId = Guid.NewGuid();
            notification.CreatedDate = DateTime.UtcNow;
            notification.IsRead = false;
            notification.IsNotified = false;
            notification.IsDeleted = false;

            _repository.NotificationRepository.CreateNotification(notification);
            await _repository.SaveAsync();

            return _mapper.Map<NotificationDto>(notification);
        }

        public async Task<NotificationDto> CreateNotificationByUsernameAsync(NotificationForCreationByUsernameDto notificationDto)
        {
            var userId = await GetUserIdFromUsernameAsync(notificationDto.Username);
            
            var notificationForCreation = new NotificationForCreationDto
            {
                UserId = userId,
                ActorId = notificationDto.ActorId,
                Title = notificationDto.Title,
                Message = notificationDto.Message,
                Content = notificationDto.Content,
                Type = notificationDto.Type,
                Data = notificationDto.Data,
                RelatedEntityId = notificationDto.RelatedEntityId,
                RelatedEntityType = notificationDto.RelatedEntityType,
                IsBroadcast = notificationDto.IsBroadcast
            };

            return await CreateNotificationAsync(notificationForCreation);
        }

        public async Task<NotificationDto> SendNotificationAsync(string userId, string title, string message, NotificationType type, string? data = null)
        {
            var notificationDto = new NotificationForCreationDto
            {
                UserId = userId,
                ActorId = null,
                Title = title,
                Message = message,
                Content = title + ": " + message,
                Type = type,
                Data = data,
                IsBroadcast = false
            };

            var notification = await CreateNotificationAsync(notificationDto);
            
            try
            {
                var username = await GetUsernameFromUserIdAsync(userId);
                await _realTimeNotificationService.SendNotificationAsync(username, notification);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send real-time notification: {ex.Message}");
            }

            return notification;
        }

        public async Task<NotificationDto> SendNotificationByUsernameAsync(string username, string title, string message, NotificationType type, string? data = null)
        {
            var userId = await GetUserIdFromUsernameAsync(username);
            return await SendNotificationAsync(userId, title, message, type, data);
        }

        public async Task SendBulkNotificationAsync(IEnumerable<string> userIds, string title, string message, NotificationType type, string? data = null)
        {
            var tasks = userIds.Select(userId => SendNotificationAsync(userId, title, message, type, data));
            await Task.WhenAll(tasks);
        }

        public async Task SendBulkNotificationByUsernamesAsync(IEnumerable<string> usernames, string title, string message, NotificationType type, string? data = null)
        {
            var userIds = new List<string>();
            foreach (var username in usernames)
            {
                var userId = await GetUserIdFromUsernameAsync(username);
                userIds.Add(userId);
            }
            await SendBulkNotificationAsync(userIds, title, message, type, data);
        }

        public async Task DeleteNotificationAsync(Guid notificationId, bool trackChanges)
        {
            var notification = await GetNotificationByIdAndCheckIfExists(notificationId, trackChanges);

            _repository.NotificationRepository.DeleteNotification(notification);
            await _repository.SaveAsync();
        }

        public async Task MarkAsNotifiedAsync(Guid notificationId, bool trackChanges)
        {
            var notification = await GetNotificationByIdAndCheckIfExists(notificationId, trackChanges);

            notification.IsNotified = true;
            _repository.NotificationRepository.UpdateNotification(notification);
            await _repository.SaveAsync();
        }

        public async Task MarkNotificationAsReadAsync(Guid notificationId)
        {
            var notification = await _repository.NotificationRepository.GetNotificationByIdAsync(notificationId, true);
            if (notification == null)
                throw new NotificationNotFoundException(notificationId);

            notification.IsRead = true;
            notification.ModifiedDate = DateTime.UtcNow;
            await _repository.SaveAsync();

            try
            {
                var username = await GetUsernameFromUserIdAsync(notification.UserId);
                await _realTimeNotificationService.SendNotificationReadAsync(username, notificationId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send real-time notification read update: {ex.Message}");
            }
        }

        public async Task MarkAllNotificationsAsReadAsync(string userId)
        {
            var notifications = await _repository.NotificationRepository.GetUnreadNotificationsAsync(userId);
            foreach (var notification in notifications)
            {
                notification.IsRead = true;
                notification.ModifiedDate = DateTime.UtcNow;
            }
            await _repository.SaveAsync();

            try
            {
                var username = await GetUsernameFromUserIdAsync(userId);
                await _realTimeNotificationService.SendAllNotificationsReadAsync(username);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send real-time all notifications read update: {ex.Message}");
            }
        }

        public async Task MarkAllNotificationsAsReadByUsernameAsync(string username)
        {
            var userId = await GetUserIdFromUsernameAsync(username);
            await MarkAllNotificationsAsReadAsync(userId);
        }

        public async Task<int> GetUnreadNotificationCountAsync(string userId)
        {
            return await _repository.NotificationRepository.GetUnreadNotificationCountAsync(userId);
        }

        public async Task<int> GetUnreadNotificationCountByUsernameAsync(string username)
        {
            var userId = await GetUserIdFromUsernameAsync(username);
            return await GetUnreadNotificationCountAsync(userId);
        }

        public async Task<IEnumerable<NotificationDto>> GetUnreadNotificationsAsync(string userId)
        {
            var notifications = await _repository.NotificationRepository.GetUnreadNotificationsAsync(userId);
            return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
        }

        public async Task<IEnumerable<NotificationDto>> GetUnreadNotificationsByUsernameAsync(string username)
        {
            var userId = await GetUserIdFromUsernameAsync(username);
            return await GetUnreadNotificationsAsync(userId);
        }

        // Business event notifications
        public async Task SendPrescriptionExpiryNotificationAsync(string userId, Guid prescriptionId, DateTime expiryDate)
        {
            await SendNotificationAsync(
                userId,
                "Prescription Expiring Soon",
                $"Your prescription will expire on {expiryDate:MM/dd/yyyy}. Please renew it soon.",
                NotificationType.PrescriptionExpiry,
                JsonSerializer.Serialize(new { prescriptionId, expiryDate })
            );
        }

        public async Task SendPrescriptionExpiryNotificationByUsernameAsync(string username, Guid prescriptionId, DateTime expiryDate)
        {
            await SendNotificationByUsernameAsync(
                username,
                "Prescription Expiring Soon",
                $"Your prescription will expire on {expiryDate:MM/dd/yyyy}. Please renew it soon.",
                NotificationType.PrescriptionExpiry,
                JsonSerializer.Serialize(new { prescriptionId, expiryDate })
            );
        }

        public async Task SendPaymentConfirmationNotificationAsync(string userId, Guid orderId, decimal amount)
        {
            await SendNotificationAsync(
                userId,
                "Payment Confirmed",
                $"Your payment of ${amount:F2} for order #{orderId} has been confirmed.",
                NotificationType.PaymentConfirmation,
                JsonSerializer.Serialize(new { orderId, amount })
            );
        }

        public async Task SendPaymentConfirmationNotificationByUsernameAsync(string username, Guid orderId, decimal amount)
        {
            await SendNotificationByUsernameAsync(
                username,
                "Payment Confirmed",
                $"Your payment of ${amount:F2} for order #{orderId} has been confirmed.",
                NotificationType.PaymentConfirmation,
                JsonSerializer.Serialize(new { orderId, amount })
            );
        }

        public async Task SendDeliveryStatusNotificationAsync(string userId, Guid orderId, string status)
        {
            await SendNotificationAsync(
                userId,
                "Delivery Status Update",
                $"Your order #{orderId} status has been updated to: {status}",
                NotificationType.DeliveryStatus,
                JsonSerializer.Serialize(new { orderId, status })
            );
        }

        public async Task SendDeliveryStatusNotificationByUsernameAsync(string username, Guid orderId, string status)
        {
            await SendNotificationByUsernameAsync(
                username,
                "Delivery Status Update",
                $"Your order #{orderId} status has been updated to: {status}",
                NotificationType.DeliveryStatus,
                JsonSerializer.Serialize(new { orderId, status })
            );
        }

        public async Task SendPriceChangeNotificationAsync(string userId, Guid productId, string productName, decimal oldPrice, decimal newPrice)
        {
            await SendNotificationAsync(
                userId,
                "Price Change Alert",
                $"The price of {productName} has changed from ${oldPrice:F2} to ${newPrice:F2}",
                NotificationType.PriceChange,
                JsonSerializer.Serialize(new { productId, productName, oldPrice, newPrice })
            );
        }

        public async Task SendPriceChangeNotificationByUsernameAsync(string username, Guid productId, string productName, decimal oldPrice, decimal newPrice)
        {
            await SendNotificationByUsernameAsync(
                username,
                "Price Change Alert",
                $"The price of {productName} has changed from ${oldPrice:F2} to ${newPrice:F2}",
                NotificationType.PriceChange,
                JsonSerializer.Serialize(new { productId, productName, oldPrice, newPrice })
            );
        }

        public async Task SendPromotionNotificationAsync(string userId, string promotionId, string promotionName, DateTime expiryDate)
        {
            await SendNotificationAsync(
                userId,
                "New Promotion Available",
                $"Don't miss out on {promotionName}! Valid until {expiryDate:MM/dd/yyyy}",
                NotificationType.Promotion,
                JsonSerializer.Serialize(new { promotionId, promotionName, expiryDate })
            );
        }

        public async Task SendPromotionNotificationByUsernameAsync(string username, string promotionId, string promotionName, DateTime expiryDate)
        {
            await SendNotificationByUsernameAsync(
                username,
                "New Promotion Available",
                $"Don't miss out on {promotionName}! Valid until {expiryDate:MM/dd/yyyy}",
                NotificationType.Promotion,
                JsonSerializer.Serialize(new { promotionId, promotionName, expiryDate })
            );
        }

        public async Task SendProductInfoNotificationAsync(string userId, string productId, string productName, string infoType, string message)
        {
            var notificationData = new
            {
                productId,
                productName,
                infoType,
                timestamp = DateTime.UtcNow
            };

            await SendNotificationAsync(
                userId,
                $"Product Update: {productName}",
                message,
                NotificationType.ProductInfo,
                JsonSerializer.Serialize(notificationData)
            );
        }

        public async Task SendProductInfoNotificationByUsernameAsync(string username, string productId, string productName, string infoType, string message)
        {
            var notificationData = new
            {
                productId,
                productName,
                infoType,
                timestamp = DateTime.UtcNow
            };

            await SendNotificationByUsernameAsync(
                username,
                $"Product Update: {productName}",
                message,
                NotificationType.ProductInfo,
                JsonSerializer.Serialize(notificationData)
            );
        }

        public async Task SendProductSpecificNotificationAsync(string userId, string productId, string productName, string infoType)
        {
            var message = infoType switch
            {
                "stock_low" => $"Low stock alert for {productName}. Please reorder soon.",
                "out_of_stock" => $"{productName} is now out of stock.",
                "back_in_stock" => $"{productName} is back in stock!",
                "price_drop" => $"Price drop alert for {productName}!",
                "new_review" => $"New review available for {productName}.",
                _ => $"Update available for {productName}."
            };

            await SendProductInfoNotificationAsync(userId, productId, productName, infoType, message);
        }

        public async Task SendProductSpecificNotificationByUsernameAsync(string username, string productId, string productName, string infoType)
        {
            var message = infoType switch
            {
                "stock_low" => $"Low stock alert for {productName}. Please reorder soon.",
                "out_of_stock" => $"{productName} is now out of stock.",
                "back_in_stock" => $"{productName} is back in stock!",
                "price_drop" => $"Price drop alert for {productName}!",
                "new_review" => $"New review available for {productName}.",
                _ => $"Update available for {productName}."
            };

            await SendProductInfoNotificationByUsernameAsync(username, productId, productName, infoType, message);
        }

        public async Task SendGroupedProductNotificationsAsync(string userId, IEnumerable<(string productId, string productName, string infoType)> updates)
        {
            var groupedMessage = string.Join("\n", updates.Select(u => $"• {u.productName}: {u.infoType}"));
            var notificationData = new
            {
                updates = updates.Select(u => new { u.productId, u.productName, u.infoType }),
                timestamp = DateTime.UtcNow
            };

            await SendNotificationAsync(
                userId,
                "Product Updates Summary",
                groupedMessage,
                NotificationType.ProductInfo,
                JsonSerializer.Serialize(notificationData)
            );
        }

        public async Task SendGroupedProductNotificationsByUsernameAsync(string username, IEnumerable<(string productId, string productName, string infoType)> updates)
        {
            var groupedMessage = string.Join("\n", updates.Select(u => $"• {u.productName}: {u.infoType}"));
            var notificationData = new
            {
                updates = updates.Select(u => new { u.productId, u.productName, u.infoType }),
                timestamp = DateTime.UtcNow
            };

            await SendNotificationByUsernameAsync(
                username,
                "Product Updates Summary",
                groupedMessage,
                NotificationType.ProductInfo,
                JsonSerializer.Serialize(notificationData)
            );
        }

        public async Task SendGroupedNotificationsAsync(string userId, string groupType, IEnumerable<(string title, string message, string type, string? data)> notifications)
        {
            var groupedMessage = string.Join("\n", notifications.Select(n => $"• {n.title}: {n.message}"));
            var notificationData = new
            {
                groupType,
                notifications = notifications.Select(n => new { n.title, n.message, n.type, n.data }),
                timestamp = DateTime.UtcNow
            };

            await SendNotificationAsync(
                userId,
                $"{groupType} Summary",
                groupedMessage,
                NotificationType.General,
                JsonSerializer.Serialize(notificationData)
            );
        }

        public async Task SendGroupedNotificationsByUsernameAsync(string username, string groupType, IEnumerable<(string title, string message, string type, string? data)> notifications)
        {
            var groupedMessage = string.Join("\n", notifications.Select(n => $"• {n.title}: {n.message}"));
            var notificationData = new
            {
                groupType,
                notifications = notifications.Select(n => new { n.title, n.message, n.type, n.data }),
                timestamp = DateTime.UtcNow
            };

            await SendNotificationByUsernameAsync(
                username,
                $"{groupType} Summary",
                groupedMessage,
                NotificationType.General,
                JsonSerializer.Serialize(notificationData)
            );
        }

        public async Task SendDailyProductUpdatesAsync(string userId, IEnumerable<(string productId, string productName, string infoType)> dailyUpdates)
        {
            await SendGroupedProductNotificationsAsync(userId, dailyUpdates);
        }

        public async Task SendDailyProductUpdatesByUsernameAsync(string username, IEnumerable<(string productId, string productName, string infoType)> dailyUpdates)
        {
            await SendGroupedProductNotificationsByUsernameAsync(username, dailyUpdates);
        }

        public async Task SendWeeklySummaryAsync(string userId, IEnumerable<(string title, string message, string type, string? data)> weeklyUpdates)
        {
            await SendGroupedNotificationsAsync(userId, "Weekly Summary", weeklyUpdates);
        }

        public async Task SendWeeklySummaryByUsernameAsync(string username, IEnumerable<(string title, string message, string type, string? data)> weeklyUpdates)
        {
            await SendGroupedNotificationsByUsernameAsync(username, "Weekly Summary", weeklyUpdates);
        }

        public async Task<PagedList<NotificationDto>> GetNotificationsAsync(NotificationRequestParameters parameters, bool trackChanges)
        {
            var pagedNotifications = await _repository.NotificationRepository.GetUserNotificationsAsync(null, parameters, trackChanges);
            var notificationDtos = _mapper.Map<IEnumerable<NotificationDto>>(pagedNotifications).ToList();
            return new PagedList<NotificationDto>(
                notificationDtos,
                pagedNotifications.MetaData.TotalCount,
                pagedNotifications.MetaData.CurrentPage,
                pagedNotifications.MetaData.PageSize
            );
        }

        private async Task<Notification> GetNotificationByIdAndCheckIfExists(Guid notificationId, bool trackChanges)
        {
            var notification = await _repository.NotificationRepository.GetNotificationByIdAsync(notificationId, trackChanges);
            if (notification == null)
                throw new NotificationNotFoundException(notificationId);

            return notification;
        }
    }
}
