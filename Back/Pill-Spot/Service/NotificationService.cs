using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class NotificationService : INotificationService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public NotificationService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<NotificationDto> notifications, MetaData metaData)> GetUserNotificationsAsync(
            string userId, NotificationRequestParameters requestParameters, bool trackChanges)
        {
            var notificationsWithMetaData = await _repository.NotificationRepository
                .GetUserNotificationsAsync(userId, requestParameters, trackChanges);

            var notificationDtos = _mapper.Map<IEnumerable<NotificationDto>>(notificationsWithMetaData);

            return (notifications: notificationDtos, metaData: notificationsWithMetaData.MetaData);
        }

        public async Task<NotificationDto> CreateNotificationAsync(NotificationForCreationDto notificationForCreationDto)
        {
            var notificationEntity = _mapper.Map<Notification>(notificationForCreationDto);
            _repository.NotificationRepository.CreateNotification(notificationEntity);
            await _repository.SaveAsync();

            return _mapper.Map<NotificationDto>(notificationEntity);
        }
        public async Task<NotificationDto> GetNotificationByIdAsync(Guid notificationId, bool trackChanges)
        {
            var notification = await GetNotificationByIdAndCheckIfExists(notificationId, trackChanges);

            return _mapper.Map<NotificationDto>(notification);
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



        private async Task<Notification> GetNotificationByIdAndCheckIfExists(Guid notificationId, bool trackChanges)
        {
            var notification = await _repository.NotificationRepository.GetNotificationByIdAsync(notificationId, trackChanges);
            if (notification == null)
                throw new NotificationNotFoundException(notificationId);

            return notification;
        }
    }
}
