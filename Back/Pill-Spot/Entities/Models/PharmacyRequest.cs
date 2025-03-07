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
        public Guid RequestId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public required string UserId { get; set; }
        public string? AdminUserId { get; set; }

        [Required(ErrorMessage = "Pharmacist license is required.")]
        [MaxLength(500, ErrorMessage = "License document URL cannot exceed 500 characters.")]
        public required string PharmacistLicenseUrl { get; set; }

        [Required(ErrorMessage = "Pharmacy name is required.")]
        [MaxLength(255, ErrorMessage = "Pharmacy name cannot exceed 255 characters.")]
        public required string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Logo URL cannot exceed 500 characters.")]
        public string? LogoURL { get; set; }

        [Required(ErrorMessage = "Location ID is required.")]
        public Guid LocationId { get; set; }

        [Required(ErrorMessage = "License ID is required.")]
        [MaxLength(450, ErrorMessage = "License ID cannot exceed 450 characters.")]
        public required string LicenseId { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [MaxLength(11, ErrorMessage = "Contact number cannot exceed 11 characters.")]
        public required string ContactNumber { get; set; }

        [Required(ErrorMessage = "Opening time is required.")]
        public TimeSpan OpeningTime { get; set; }

        [Required(ErrorMessage = "Closing time is required.")]
        public TimeSpan ClosingTime { get; set; }

        [Required(ErrorMessage = "IsOpen24 is required.")]
        public bool IsOpen24 { get; set; }

        [Required(ErrorMessage = "Days open is required.")]
        [MaxLength(50)]
        public required string DaysOpen { get; set; }

        [Required]
        public PharmacyRequestStatus Status { get; set; } = PharmacyRequestStatus.Pending;

        public string? AdminMessage { get; set; }

        [Required]
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        public DateTime? DecisionDate { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
        [ForeignKey("AdminUserId")]
        public virtual User? AdminUser { get; set; }
    }
}
