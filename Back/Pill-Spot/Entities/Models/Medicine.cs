using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Medicine : Product
    {
        [Required(ErrorMessage = "Manufacturer is required.")]
        [MaxLength(250, ErrorMessage = "Manufacturer cannot exceed 250 characters.")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Dosage is required.")]
        [Range(0.01, float.MaxValue, ErrorMessage = "Dosage must be greater than zero.")]
        public float Dosage { get; set; }

        [Required(ErrorMessage = "Side effects are required.")]
        [MaxLength(500, ErrorMessage = "Side effects cannot exceed 500 characters.")]
        public string SideEffects { get; set; }

        [Required(ErrorMessage = "Prescription requirement is required.")]
        public bool IsPrescriptionRequired { get; set; }

        [Required]
        public virtual Product Product { get; set; }
    }
}