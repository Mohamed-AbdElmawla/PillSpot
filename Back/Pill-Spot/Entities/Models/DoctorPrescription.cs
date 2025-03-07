using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class DoctorPrescription
    {
        [Key]
        public Guid PrescriptionId { get; set; }

        [Required(ErrorMessage = "Doctor ID is required.")]
        public required string DoctorId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public required string UserId { get; set; }

        [MaxLength(500, ErrorMessage = "Instructions cannot exceed 500 characters.")]
        public required string Instructions { get; set; }

        [ForeignKey("PrescriptionId")]
        public virtual Prescription Prescription { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}