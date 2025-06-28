using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record PrescriptionProductForUpdateDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; init; }

        public string? Dosage { get; init; }

        public string? Instructions { get; init; }
    }
}