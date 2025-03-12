using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record CityForUpdateDto
    {
        [MaxLength(250, ErrorMessage = "City name cannot exceed 250 characters.")]
        public string? CityName { get; init; }

        public Guid? GovernmentId { get; init; }

    }
}
