using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record PharmacyProductForUpdateDto
    {
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int? Quantity { get; init; }
        
        public bool? IsAvailable { get; init; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Minimum stock threshold must be a non-negative number.")]
        public int? MinimumStockThreshold { get; init; }
    }
} 