using System;
using System.Collections.Generic;

namespace Shared.DataTransferObjects
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public LocationDto LocationDto { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int Status { get; set; }
        public int PaymentMethod { get; set; }
        public bool IsSuccessful { get; set; }
        public int Currency { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
