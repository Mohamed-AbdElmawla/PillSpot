using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record PharmacyEmployeeForUpdateDto
    {
        [Required(ErrorMessage = "Role is required.")]
        [MaxLength(100, ErrorMessage = "Role cannot exceed 100 characters.")]
        public required string Role { get; init; }

        [Required(ErrorMessage = "Hire date is required.")]
        public DateTime HireDate { get; init; }
        public bool IsDeleted { get; init; }
    }
}
