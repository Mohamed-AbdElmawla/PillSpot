using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Notification
    {
        [Key]
        public Guid NotificationId { get; set; }

        [Required]
        public string UserId { get; set; }

        public string? ActorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Message { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        public NotificationType Type { get; set; }

        public string? Data { get; set; }

        public Guid? RelatedEntityId { get; set; }

        public string? RelatedEntityType { get; set; }

        [Required]
        public bool IsRead { get; set; }

        [Required]
        public bool IsNotified { get; set; }

        [Required]
        public bool IsBroadcast { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? NotifiedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(ActorId))]
        public User Actor { get; set; }
    }

    public enum NotificationType
    {
        General,
        PrescriptionExpiry,
        PaymentConfirmation,
        DeliveryStatus,
        PriceChange,
        Promotion,
        ProductInfo,
        GroupedProductInfo,
        GroupedNotification,
        StockAlert,
        PriceDrop,
        NewReview,
        SideEffect,
        Alternative,
        Recall,
        Restock,
        Discount,
        CartItemAdded,
        CartItemRemoved,
        CartItemQuantityUpdated,
        CartItemApprovalStatusUpdated,
        CartItemApprovalStatusRejected,
        CartItemApprovalStatusApproved,
        CartItemApprovalStatusPending,
        CartItemApprovalStatusCancelled,
        CartItemApprovalStatusExpired,
        OrderCreated,
        NewOrder,
        RequestUpdate
    }
}
