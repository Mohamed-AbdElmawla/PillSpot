using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class DoctorPrescription
    {
        [Key]
        public ulong PrescriptionID { get; set; }

        [Required(ErrorMessage = "Doctor ID is required.")]
        public string DoctorId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public string UserID { get; set; }

        [MaxLength(500, ErrorMessage = "Instructions cannot exceed 500 characters.")]
        public string Instructions { get; set; }

        [ForeignKey("PrescriptionID")]
        public virtual Prescription Prescription { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}