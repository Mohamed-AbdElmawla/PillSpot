using System;

namespace Shared.DataTransferObjects
{
    public class CartForUpdateDto
    {
        public Guid? DeliveryAddressId { get; init; }
        public bool? IsLocked { get; init; }
    }
}