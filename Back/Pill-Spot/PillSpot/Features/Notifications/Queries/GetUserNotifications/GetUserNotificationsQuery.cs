using MediatR;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace PillSpot.Features.Notifications.Queries.GetUserNotifications
{
    public record GetUserNotificationsQuery : IRequest<(IEnumerable<NotificationDto> notifications, MetaData metaData)>
    {
        public string UserId { get; init; }
        public NotificationRequestParameters Parameters { get; init; }
    }
} 