using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Prescription
    {
        [Key]
        public Guid PrescriptionId { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Issue date is required")]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "Expiry date is required")]
        public DateTime ExpiryDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public PrescriptionStatus Status { get; set; } = PrescriptionStatus.Active;

        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<PrescriptionProduct> PrescriptionProducts { get; set; }
    }

    public enum PrescriptionStatus
    {
        Active,
        Expired,
        Used,
        Rejected,
        PendingVerification
    }
}