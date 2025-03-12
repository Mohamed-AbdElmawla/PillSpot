using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record PharmacyEmployeeRequestCreateDto
    {
        [Required]
        public required string UserId { get; set; }
        [Required]
        public Guid PharmacyId { get; set; }
    }
}
