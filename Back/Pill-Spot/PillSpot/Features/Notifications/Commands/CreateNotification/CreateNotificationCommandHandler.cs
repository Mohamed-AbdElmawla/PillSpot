using MediatR;
using Microsoft.AspNetCore.SignalR;
using Service.Contracts;
using Service.Contracts.Notifications.Commands;
using Service.Hubs;
using Shared.DataTransferObjects;
using System.Security.Claims;

namespace PillSpot.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, NotificationDto>
    {
        private readonly IServiceManager _serviceManager;
        private readonly IHubContext<NotificationHub> _hubContext;

        public CreateNotificationCommandHandler(
            IServiceManager serviceManager,
            IHubContext<NotificationHub> hubContext)
        {
            _serviceManager = serviceManager;
            _hubContext = hubContext;
        }

        public async Task<NotificationDto> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            // Get the current user's ID from the request context
            var actorId = request.ActorId ?? "system"; // If no actor specified, use "system"

            // Create notification in database
            var notification = await _serviceManager.NotificationService.CreateNotificationAsync(
                new NotificationForCreationDto
                {
                    UserId = request.UserId,
                    ActorId = actorId,
                    Title = request.Title,
                    Message = request.Message,
                    Content = request.Message, // Using message as content for now
                    Type = request.Type,
                    Data = request.Data,
                    IsBroadcast = request.IsBroadcast
                });

            // Send real-time notification
            await _hubContext.Clients
                .Group(request.UserId)
                .SendAsync("ReceiveNotification", notification, cancellationToken);

            return notification;
        }
    }
} 