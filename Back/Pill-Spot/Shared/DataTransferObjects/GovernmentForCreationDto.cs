using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record GovernmentForCreationDto
    {
        [Required(ErrorMessage = "Government name is required.")]
        [MaxLength(250, ErrorMessage = "Government name cannot exceed 250 characters.")]
        public required string GovernmentName { get; init; }
    }
}
