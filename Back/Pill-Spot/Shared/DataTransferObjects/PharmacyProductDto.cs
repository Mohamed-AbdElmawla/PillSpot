using System;

namespace Shared.DataTransferObjects
{
    public record PharmacyProductDto
    {
        public ulong ProductId { get; init; }
        public ulong PharmacyId { get; init; }
        public ulong BatchId { get; init; }
        public int Quantity { get; init; }
        public ProductDto Product { get; init; }
        public PharmacyDto Pharmacy { get; init; }
        public BatchDto Batch { get; init; }
    }
}