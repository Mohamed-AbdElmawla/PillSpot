using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class PharmacyProductNotificationPreference
    {
        [Key]
        public Guid PreferenceId { get; set; }
        
        public string UserId { get; set; }
        public Guid ProductId { get; set; }
        public Guid? PharmacyId { get; set; } // null means any pharmacy
        public bool IsEnabled { get; set; }
        public List<string> NotificationTypes { get; set; } = new List<string>();
        public DateTime CreatedAt { get; set; }
        public DateTime? LastNotifiedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [ForeignKey(nameof(PharmacyId))]
        public Pharmacy? Pharmacy { get; set; }
    }
} 