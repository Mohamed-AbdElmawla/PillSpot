using System;
using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Shared.DataTransferObjects
{
    public record NotificationForCreationDto
    {
        [Required(ErrorMessage = "User ID is required")]
        public string UserId { get; init; }

        public string? ActorId { get; init; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; init; }

        [Required(ErrorMessage = "Message is required")]
        [MaxLength(500, ErrorMessage = "Message cannot exceed 500 characters")]
        public string Message { get; init; }

        [Required(ErrorMessage = "Content is required")]
        [MaxLength(1000, ErrorMessage = "Content cannot exceed 1000 characters")]
        public string Content { get; init; }

        [Required(ErrorMessage = "Type is required")]
        public NotificationType Type { get; init; }

        public string? Data { get; init; }
        public Guid? RelatedEntityId { get; init; }
        public string? RelatedEntityType { get; init; }
        public bool IsBroadcast { get; init; } = false;
    }

    public record NotificationForCreationByUsernameDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; init; }

        public string? ActorId { get; init; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; init; }

        [Required(ErrorMessage = "Message is required")]
        [MaxLength(500, ErrorMessage = "Message cannot exceed 500 characters")]
        public string Message { get; init; }

        [Required(ErrorMessage = "Content is required")]
        [MaxLength(1000, ErrorMessage = "Content cannot exceed 1000 characters")]
        public string Content { get; init; }

        [Required(ErrorMessage = "Type is required")]
        public NotificationType Type { get; init; }

        public string? Data { get; init; }
        public Guid? RelatedEntityId { get; init; }
        public string? RelatedEntityType { get; init; }
        public bool IsBroadcast { get; init; } = false;
    }
}
