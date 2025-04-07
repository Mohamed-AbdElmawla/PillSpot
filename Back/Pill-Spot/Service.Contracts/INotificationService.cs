using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface INotificationService
    {
        Task<(IEnumerable<NotificationDto> notifications, MetaData metaData)> GetUserNotificationsAsync(string userId, NotificationRequestParameters requestParameters, bool trackChanges);
        Task<NotificationDto> CreateNotificationAsync(NotificationForCreationDto notificationForCreationDto);
        Task<NotificationDto> GetNotificationByIdAsync(Guid notificationId, bool trackChanges);
        Task DeleteNotificationAsync(Guid notificationId, bool trackChanges);
        Task MarkAsNotifiedAsync(Guid notificationId, bool trackChanges);
    }
}
