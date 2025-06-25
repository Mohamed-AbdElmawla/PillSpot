using Entities.Models;
using Shared.DataTransferObjects;
using System;
using MediatR;

namespace Service.Contracts.Notifications.Commands
{
    public record CreateNotificationCommand : IRequest<NotificationDto>
    {
        public string UserId { get; init; }
        public string? ActorId { get; init; }
        public string Title { get; init; }
        public string Message { get; init; }
        public NotificationType Type { get; init; }
        public string? Data { get; init; }
        public bool IsBroadcast { get; init; } = false;
        public Guid? RelatedEntityId { get; init; }
        public string? RelatedEntityType { get; init; }
    }

    public record CreateNotificationByUsernameCommand : IRequest<NotificationDto>
    {
        public string Username { get; init; }
        public string? ActorId { get; init; }
        public string Title { get; init; }
        public string Message { get; init; }
        public NotificationType Type { get; init; }
        public string? Data { get; init; }
        public bool IsBroadcast { get; init; } = false;
        public Guid? RelatedEntityId { get; init; }
        public string? RelatedEntityType { get; init; }
    }
} 