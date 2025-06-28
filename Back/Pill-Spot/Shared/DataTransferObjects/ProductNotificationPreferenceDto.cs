using System;
using System.Collections.Generic;

namespace Shared.DataTransferObjects
{
    public class ProductNotificationPreferenceDto
    {
        public Guid PreferenceId { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> NotificationTypes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastNotifiedAt { get; set; }
    }

    public class ProductNotificationPreferenceForCreationDto
    {
        public bool IsEnabled { get; set; }
        public List<string> NotificationTypes { get; set; }
    }

    public class ProductNotificationPreferenceForUpdateDto
    {
        public bool IsEnabled { get; set; }
        public List<string> NotificationTypes { get; set; }
    }
} 