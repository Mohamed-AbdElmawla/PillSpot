using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Pharmacy
    {
        [Key]
        public Guid PharmacyId { get; set; }

        [ForeignKey("ParentPharmacy")]
        public Guid? ParentPharmacyId { get; set; }
        public virtual Pharmacy? ParentPharmacy { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(255, ErrorMessage = "Name cannot exceed 255 characters.")]
        public required string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Image URL cannot exceed 500 characters.")]
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
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public virtual ICollection<Pharmacy> Branches { get; set; } = new List<Pharmacy>();
        public virtual ICollection<PharmacyEmployee> Employees { get; set; } = new List<PharmacyEmployee>();
        public virtual ICollection<PharmacyProduct> PharmacyProducts { get; set; } = new List<PharmacyProduct>();

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public bool IsActive { get; set; } = true; 
    }
}