using AutoMapper;
using Service.Contracts;
using Service.Contracts.Notifications.Queries;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Notifications.Queries
{
    public class GetNotificationsQueryHandler
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public GetNotificationsQueryHandler(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<GetNotificationsQueryResult> HandleAsync(GetNotificationsQuery query)
        {
            var parameters = new NotificationRequestParameters
            {
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
            var pagedNotifications = await _notificationService.GetNotificationsAsync(parameters, false);
            var notificationDtos = _mapper.Map<IEnumerable<NotificationDto>>(pagedNotifications);
            var totalPages = (int)Math.Ceiling(pagedNotifications.MetaData.TotalCount / (double)query.PageSize);

            return new GetNotificationsQueryResult
            {
                Notifications = notificationDtos,
                TotalCount = pagedNotifications.MetaData.TotalCount,
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
                TotalPages = totalPages
            };
        }
    }
} 