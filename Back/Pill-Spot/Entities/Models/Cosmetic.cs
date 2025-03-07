using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public enum SkinType
    {
        Normal,
        Oily,
        Dry,
        Combination,
        Sensitive
    }

    public class Cosmetic : Product
    {
        [Required(ErrorMessage = "Brand is required.")]
        [MaxLength(250, ErrorMessage = "Brand cannot exceed 250 characters.")]
        public required string Brand { get; set; }

        [Required(ErrorMessage = "Skin type is required.")]
        public SkinType SkinType { get; set; }

        [Required(ErrorMessage = "Usage instructions are required.")]
        [MaxLength(500, ErrorMessage = "Usage instructions cannot exceed 500 characters.")]
        public required string UsageInstructions { get; set; }

        [Required(ErrorMessage = "Volume is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Volume must be greater than zero.")]
        public int Volume { get; set; }
    }
}