using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record CosmeticForCreationDto : ProductForCreationDto
    {
        [Required(ErrorMessage = "Brand is required.")]
        [MaxLength(250, ErrorMessage = "Brand cannot exceed 250 characters.")]
        public required string Brand { get; init; }
        [Required(ErrorMessage = "Skin type is required.")]
        public SkinType SkinType { get; init; }
        [Required(ErrorMessage = "Volume is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Volume must be greater than zero.")]
        public int Volume { get; init; }
    }
}
