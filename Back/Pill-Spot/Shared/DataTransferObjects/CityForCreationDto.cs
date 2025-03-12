using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record CityForCreationDto
    {
        [Required(ErrorMessage = "City name is required.")]
        [MaxLength(250, ErrorMessage = "City name in English cannot exceed 250 characters.")]
        public required string CityName { get; init; }

        [Required(ErrorMessage = "Government ID is required.")]
        public Guid GovernmentId { get; init; }
    }
}
