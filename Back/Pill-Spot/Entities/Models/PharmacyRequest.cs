using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public enum PharmacyRequestStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class PharmacyRequest
    {
        [Key]
        public ulong RequestId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required(ErrorMessage = "Pharmacist license is required.")]
        [MaxLength(500, ErrorMessage = "License document URL cannot exceed 500 characters.")]
        public string PharmacistLicenseUrl { get; set; }

        [Required(ErrorMessage = "Pharmacy name is required.")]
        [MaxLength(255, ErrorMessage = "Pharmacy name cannot exceed 255 characters.")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Logo URL cannot exceed 500 characters.")]
        public string? LogoURL { get; set; }

        [Required(ErrorMessage = "Location ID is required.")]
        public Guid LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        [Required(ErrorMessage = "License ID is required.")]
        [MaxLength(450, ErrorMessage = "License ID cannot exceed 450 characters.")]
        public string LicenseId { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [MaxLength(11, ErrorMessage = "Contact number cannot exceed 11 characters.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Opening time is required.")]
        public TimeSpan OpeningTime { get; set; }

        [Required(ErrorMessage = "Closing time is required.")]
        public TimeSpan ClosingTime { get; set; }

        [Required(ErrorMessage = "IsOpen24 is required.")]
        public bool IsOpen24 { get; set; }

        [Required(ErrorMessage = "Days open is required.")]
        [MaxLength(50)]
        public string DaysOpen { get; set; }

        [Required]
        public PharmacyRequestStatus Status { get; set; } = PharmacyRequestStatus.Pending;

        public string? AdminMessage { get; set; }

        public string? AdminUserId { get; set; }
        [ForeignKey("AdminUserId")]
        public virtual User? AdminUser { get; set; }

        [Required]
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        public DateTime? DecisionDate { get; set; }
    }
}
