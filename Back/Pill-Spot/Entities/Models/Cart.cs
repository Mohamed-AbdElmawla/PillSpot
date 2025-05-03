using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        [Key]
        public Guid CartId { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public virtual User? User { get; set; }

        [Required]
        [MaxLength(50)]
        public string CartType { get; set; } = "User"; // "User" or "Guest"

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastAccessed { get; set; }
        public DateTime? ExpiresAt { get; set; } // Set to Now + 7 days for guest carts

        public Guid? DeliveryAddressId { get; set; }
        [ForeignKey("DeliveryAddressId")]
        public virtual UserAddress? DeliveryAddress { get; set; }
        [NotMapped]
        public decimal TotalPrice => Items?.Sum(item => item.PriceAtAddition * item.Quantity) ?? 0;

        public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();
        [Required]
        public bool IsDeleted { get; set; } = false;

        [Required]
        public bool IsLocked { get; set; } = false;
        public DateTime? LockedAt { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
