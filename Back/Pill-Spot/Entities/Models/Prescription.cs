using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Prescription
    {
        [Key]
        public Guid PrescriptionId { get; set; }

        [Required(ErrorMessage = "Created date is required.")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [MaxLength(500, ErrorMessage = "File path cannot exceed 500 characters.")]
        public string? FilePath { get; set; }

        public virtual ICollection<ProductPrescription> ProductPrescriptions { get; set; } = new List<ProductPrescription>();

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}