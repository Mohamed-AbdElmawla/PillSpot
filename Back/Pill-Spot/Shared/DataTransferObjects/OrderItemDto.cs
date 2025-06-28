using System;

namespace Shared.DataTransferObjects
{
    public class OrderItemDto
    {
        public Guid OrderItemId { get; set; }
        public Guid ProductId { get; set; }
        public Guid PharmacyBranchId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
