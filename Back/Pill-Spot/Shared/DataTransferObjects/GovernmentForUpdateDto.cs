using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record GovernmentForUpdateDto
    {
        [Required(ErrorMessage = "Government name is required.")]
        [MaxLength(250, ErrorMessage = "Government name cannot exceed 250 characters.")]
        public string? GovernmentName { get; init; }
        public bool IsDeleted { get; init; }
    }
}
