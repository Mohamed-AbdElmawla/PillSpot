using System;

namespace Entities.Exceptions
{
    public sealed class InsufficientStockException : BadRequestException
    {
        public InsufficientStockException(Guid productId, Guid pharmacyId, int requestedQuantity, int availableQuantity)
            : base($"Insufficient stock for product {productId} in pharmacy {pharmacyId}. Requested: {requestedQuantity}, Available: {availableQuantity}.") { }
    }
}