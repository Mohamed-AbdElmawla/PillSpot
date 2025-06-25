using MediatR;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace PillSpot.Features.Notifications.Queries.GetUserNotifications
{
    public class GetUserNotificationsQueryHandler : IRequestHandler<GetUserNotificationsQuery, (IEnumerable<NotificationDto> notifications, MetaData metaData)>
    {
        private readonly IServiceManager _serviceManager;

        public GetUserNotificationsQueryHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<(IEnumerable<NotificationDto> notifications, MetaData metaData)> Handle(
            GetUserNotificationsQuery request, 
            CancellationToken cancellationToken)
        {
            var pagedList = await _serviceManager.NotificationService.GetUserNotificationsAsync(
                request.UserId, 
                request.Parameters, 
                trackChanges: false);
            
            return (pagedList, pagedList.MetaData);
        }
    }
} 