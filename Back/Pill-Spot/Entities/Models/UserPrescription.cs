using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class UserPrescription
    {
        [Key]
        public Guid PrescriptionId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [MaxLength(450, ErrorMessage = "User ID cannot exceed 450 characters.")]
        public required string UserId { get; set; }

        [ForeignKey("PrescriptionId")]
        public virtual Prescription Prescription { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}