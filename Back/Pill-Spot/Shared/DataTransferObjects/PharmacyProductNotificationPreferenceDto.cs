using System;
using System.Collections.Generic;
using Entities.Models;

namespace Shared.DataTransferObjects
{
    public class PharmacyProductNotificationPreferenceDto
    {
        public Guid PreferenceId { get; set; }
        public string UserId { get; set; }
        public Guid ProductId { get; set; }
        public Guid? PharmacyId { get; set; }
        public string? PharmacyName { get; set; }
        public string ProductName { get; set; }
        public bool IsEnabled { get; set; }
        public List<NotificationType> NotificationTypes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastNotifiedAt { get; set; }
    }

    public class PharmacyProductNotificationPreferenceForCreationDto
    {
        public Guid? PharmacyId { get; set; }
        public bool IsEnabled { get; set; }
        public List<NotificationType> NotificationTypes { get; set; }
    }

    public class PharmacyProductNotificationPreferenceForUpdateDto
    {
        public bool IsEnabled { get; set; }
        public List<NotificationType> NotificationTypes { get; set; }
    }
} 