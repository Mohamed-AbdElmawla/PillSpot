using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class OrderDto
    {
        public string OrderId { get; init; }
        public DateTime OrderedAt { get; init; }
        public decimal TotalPrice { get; init; }
        public string Status { get; init; }
        public string UserId { get; init; }
        public string LocationId { get; init; }
        public IEnumerable<OrderItemDto> OrderItems { get; init; }
    }
}
