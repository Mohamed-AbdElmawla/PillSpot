using System;
using System.Collections.Generic;

namespace Shared.DataTransferObjects
{
    public class CartDto
    {
        public Guid CartId { get; init; }
        public string? UserId { get; init; }  // Keep as string for ASP.NET Identity
        public string CartType { get; init; }
        public bool IsLocked { get; init; }
        public DateTime? LockedAt { get; init; }
        public DateTime? ExpiresAt { get; init; }
        public DateTime LastAccessed { get; init; }
        public Guid? DeliveryAddressId { get; init; }
        public UserAddressDto? DeliveryAddress { get; init; }
        public IEnumerable<CartItemDto>? Items { get; init; }
        public int ItemCount { get; init; }
        public decimal TotalPrice { get; init; }
    }
}