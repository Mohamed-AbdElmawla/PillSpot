using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public class PharmacyEmployeeForCreationDto
    {
        [Required(ErrorMessage = "User ID is required.")]
        public required string UserId { get; init; }

        [Required(ErrorMessage = "Pharmacy ID is required.")]
        public Guid PharmacyId { get; init; }

        [Required(ErrorMessage = "Role is required.")]
        [MaxLength(100, ErrorMessage = "Role cannot exceed 100 characters.")]
        public required string Role { get; init; }

        [Required(ErrorMessage = "Hire date is required.")]
        public DateTime HireDate { get; init; }
    }
}