using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record PharmacyEmployeeRequestCreateDto
    {
        [Required]
        public required string Email { get; init; }

        [Required]
        public Guid PharmacyId { get; init; }
    }
}
