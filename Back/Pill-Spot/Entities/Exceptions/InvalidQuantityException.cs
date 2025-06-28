using System;

namespace Entities.Exceptions
{
    public sealed class InvalidQuantityException : BadRequestException
    {
        public InvalidQuantityException(int quantity)
            : base($"Quantity {quantity} is invalid. Quantity must be greater than or equal to 1.") { }
    }
}