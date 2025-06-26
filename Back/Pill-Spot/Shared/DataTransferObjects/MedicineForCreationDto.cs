using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record MedicineForCreationDto : ProductForCreationDto
    {
        [Required(ErrorMessage = "Dosage is required.")]
        [Range(0.01, float.MaxValue, ErrorMessage = "Dosage must be greater than zero.")]
        public float Dosage { get; init; }
        [Required(ErrorMessage = "Side effects are required.")]
        [MaxLength(500, ErrorMessage = "Side effects cannot exceed 500 characters.")]
        public string SideEffects { get; init; }
        [Required(ErrorMessage = "Prescription requirement is required.")]
        public bool IsPrescriptionRequired { get; init; }
    }
}
