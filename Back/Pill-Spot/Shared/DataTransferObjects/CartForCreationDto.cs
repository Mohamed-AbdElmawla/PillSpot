using System;

namespace Shared.DataTransferObjects
{
    public class CartForCreationDto
    {
        public string? UserId { get; init; }
        public string CartType { get; init; }
        public Guid? DeliveryAddressId { get; init; }
    }
}