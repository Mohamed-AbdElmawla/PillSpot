using System;
using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Shared.DataTransferObjects
{
    public record NotificationDto
    {
        public Guid NotificationId { get; init; }
        public string UserId { get; init; }
        public string ActorId { get; init; }
        public string Title { get; init; }
        public string Message { get; init; }
        public string Content { get; init; }
        public NotificationType Type { get; init; }
        public string? Data { get; init; }
        public Guid? RelatedEntityId { get; init; }
        public string? RelatedEntityType { get; init; }
        public bool IsRead { get; init; }
        public bool IsNotified { get; init; }
        public bool IsBroadcast { get; init; }
        public bool IsDeleted { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime? NotifiedDate { get; init; }
        public DateTime? ModifiedDate { get; init; }
    }

    

    public record NotificationForUpdateDto
    {
        public string? Title { get; init; }
        public string? Message { get; init; }
        public string? Content { get; init; }
        public NotificationType? Type { get; init; }
        public string? Data { get; init; }
        public Guid? RelatedEntityId { get; init; }
        public string? RelatedEntityType { get; init; }
        public bool? IsRead { get; init; }
        public bool? IsNotified { get; init; }
        public bool? IsBroadcast { get; init; }
        public bool? IsDeleted { get; init; }
    }
}
