using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Service.Contracts;
using Service.Hubs;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service
{
    public class NotificationService : INotificationService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMediator _mediator;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IMapper _mapper;

        public NotificationService(
            IRepositoryManager repository,
            IMediator mediator,
            IHubContext<NotificationHub> hubContext,
            IMapper mapper)
        {
            _repository = repository;
            _mediator = mediator;
            _hubContext = hubContext;
            _mapper = mapper;
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

        public async Task SendNotificationAsync(string userId, string title, string message, NotificationType type, string? data = null)
        {
            var notificationDto = new NotificationForCreationDto
            {
                UserId = userId,
                ActorId = "system",
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
                await _hubContext.Clients.Group(userId).SendAsync("ReceiveNotification", notification);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send real-time notification: {ex.Message}");
            }
        }

        public async Task SendBulkNotificationAsync(IEnumerable<string> userIds, string title, string message, NotificationType type, string? data = null)
        {
            var tasks = userIds.Select(userId => SendNotificationAsync(userId, title, message, type, data));
            await Task.WhenAll(tasks);
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

            await _hubContext.Clients.Group(notification.UserId)
                .SendAsync("NotificationRead", notificationId);
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

            await _hubContext.Clients.Group(userId)
                .SendAsync("AllNotificationsRead");
        }

        public async Task<int> GetUnreadNotificationCountAsync(string userId)
        {
            return await _repository.NotificationRepository.GetUnreadNotificationCountAsync(userId);
        }

        public async Task<IEnumerable<NotificationDto>> GetUnreadNotificationsAsync(string userId)
        {
            var notifications = await _repository.NotificationRepository.GetUnreadNotificationsAsync(userId);
            return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
        }

        // Additional notification types for various business events
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

        public async Task SendDeliveryStatusNotificationAsync(string userId, Guid orderId, string status)
        {
            await SendNotificationAsync(
                userId,
                "Delivery Status Update",
                $"Your order #{orderId} is now {status}.",
                NotificationType.DeliveryStatus,
                JsonSerializer.Serialize(new { orderId, status })
            );
        }

        public async Task SendPriceChangeNotificationAsync(string userId, Guid productId, string productName, decimal oldPrice, decimal newPrice)
        {
            await SendNotificationAsync(
                userId,
                "Price Change Alert",
                $"The price of {productName} has changed from ${oldPrice:F2} to ${newPrice:F2}.",
                NotificationType.PriceChange,
                JsonSerializer.Serialize(new { productId, productName, oldPrice, newPrice })
            );
        }

        public async Task SendPromotionNotificationAsync(string userId, string promotionId, string promotionName, DateTime expiryDate)
        {
            await SendNotificationAsync(
                userId,
                "New Promotion Available",
                $"New promotion: {promotionName}. Valid until {expiryDate:MM/dd/yyyy}.",
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

        public async Task SendProductSpecificNotificationAsync(string userId, string productId, string productName, string infoType)
        {
            string message = infoType switch
            {
                "StockAlert" => $"The product '{productName}' is now back in stock!",
                "PriceDrop" => $"The price of '{productName}' has been reduced!",
                "NewReview" => $"A new review has been posted for '{productName}'",
                "SideEffect" => $"New side effect information available for '{productName}'",
                "Alternative" => $"Alternative products are now available for '{productName}'",
                "Recall" => $"Important: Product recall notice for '{productName}'",
                "Restock" => $"'{productName}' will be restocked soon",
                "Discount" => $"Special discount available for '{productName}'",
                _ => $"New information available for '{productName}'"
            };

            await SendProductInfoNotificationAsync(userId, productId, productName, infoType, message);
        }

        // New methods for grouped notifications
        public async Task SendGroupedProductNotificationsAsync(string userId, IEnumerable<(string productId, string productName, string infoType)> updates)
        {
            var groupedUpdates = updates.GroupBy(u => u.infoType);
            foreach (var group in groupedUpdates)
            {
                var products = group.Select(u => new { u.productId, u.productName }).ToList();
                var message = group.Key switch
                {
                    "StockAlert" => $"The following products are now back in stock: {string.Join(", ", products.Select(p => p.productName))}",
                    "PriceDrop" => $"Price drops for: {string.Join(", ", products.Select(p => p.productName))}",
                    "NewReview" => $"New reviews available for: {string.Join(", ", products.Select(p => p.productName))}",
                    "SideEffect" => $"New side effect information for: {string.Join(", ", products.Select(p => p.productName))}",
                    "Alternative" => $"Alternative products available for: {string.Join(", ", products.Select(p => p.productName))}",
                    "Recall" => $"Important recall notices for: {string.Join(", ", products.Select(p => p.productName))}",
                    "Restock" => $"Upcoming restock for: {string.Join(", ", products.Select(p => p.productName))}",
                    "Discount" => $"Special discounts for: {string.Join(", ", products.Select(p => p.productName))}",
                    _ => $"Updates available for: {string.Join(", ", products.Select(p => p.productName))}"
                };

                var notificationData = new
                {
                    products = products,
                    infoType = group.Key,
                    timestamp = DateTime.UtcNow
                };

                await SendNotificationAsync(
                    userId,
                    $"Product Updates: {group.Key}",
                    message,
                    NotificationType.GroupedProductInfo,
                    JsonSerializer.Serialize(notificationData)
                );
            }
        }

        public async Task SendGroupedNotificationsAsync(string userId, string groupType, IEnumerable<(string title, string message, string type, string? data)> notifications)
        {
            var groupedNotifications = notifications.GroupBy(n => n.type);
            foreach (var group in groupedNotifications)
            {
                var messages = group.Select(n => new { n.title, n.message, n.data }).ToList();
                var summaryMessage = string.Join("\n", messages.Select(m => $"- {m.message}"));

                var notificationData = new
                {
                    notifications = messages,
                    groupType,
                    timestamp = DateTime.UtcNow
                };

                await SendNotificationAsync(
                    userId,
                    $"Grouped Updates: {groupType}",
                    summaryMessage,
                    NotificationType.GroupedNotification,
                    JsonSerializer.Serialize(notificationData)
                );
            }
        }

        public async Task SendDailyProductUpdatesAsync(string userId, IEnumerable<(string productId, string productName, string infoType)> dailyUpdates)
        {
            await SendGroupedProductNotificationsAsync(userId, dailyUpdates);
        }

        public async Task SendWeeklySummaryAsync(string userId, IEnumerable<(string title, string message, string type, string? data)> weeklyUpdates)
        {
            await SendGroupedNotificationsAsync(userId, "Weekly Summary", weeklyUpdates);
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
