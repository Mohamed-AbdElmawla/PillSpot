using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public enum CartItemApprovalStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public enum RejectionType
    {
        Prescription,
        Stock, 
        Pricing,
        Policy,
        Other
    }

    public class CartItem
    {
        [Key]
        public Guid CartItemId { get; set; }

        // Basic fields
        [Required]
        [ForeignKey("Cart")]
        public Guid CartId { get; set; }
        public virtual Cart Cart { get; set; }

        [Required]
        public Guid PharmacyId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        // Prescription fields
        public string? PrescriptionImageUrl { get; set; }
        public DateTime? PrescriptionUploadedAt { get; set; }

        // Pharmacy response fields
        public CartItemApprovalStatus? PharmacyApproved { get; set; } 
        public DateTime? PharmacyRespondedAt { get; set; }

        // Rejection details (for any rejection reason)
        [MaxLength(500)]
        public string? RejectionReason { get; set; }

        // Categorize rejection types using an enum
        public RejectionType? RejectionType { get; set; }

        [ForeignKey("RespondedByUserId")]
        public string? RespondedByUserId { get; set; } // Pharmacy staff who responded
        public virtual User? RespondedByUser { get; set; }

        // Price/distance info
        public decimal PriceAtAddition { get; set; }

        // Quantity
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        [ForeignKey("PharmacyId,ProductId")]
        public virtual PharmacyProduct PharmacyProduct { get; set; }

        // Soft deletes
        [Required]
        public bool IsDeleted { get; set; } = false;

        // Concurrency control
        [Timestamp]
        public byte[] RowVersion { get; set; }

        // Computed properties
        [NotMapped]
        public decimal TotalPrice => PriceAtAddition * Quantity;
    }
}