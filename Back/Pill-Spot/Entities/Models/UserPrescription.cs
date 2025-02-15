using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class UserPrescription
    {
        [Key]
        public ulong PrescriptionID { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [MaxLength(450, ErrorMessage = "User ID cannot exceed 450 characters.")]
        public string UserID { get; set; }

        [ForeignKey("PrescriptionID")]
        public virtual Prescription Prescription { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}