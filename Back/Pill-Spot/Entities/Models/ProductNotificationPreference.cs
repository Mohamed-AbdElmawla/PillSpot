using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ProductNotificationPreference
    {
        [Key]
        public Guid PreferenceId { get; set; }
        
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> NotificationTypes { get; set; } = new List<string>();
        public DateTime CreatedAt { get; set; }
        public DateTime? LastNotifiedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
} 