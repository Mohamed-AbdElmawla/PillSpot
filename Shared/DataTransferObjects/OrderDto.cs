using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int LocationId { get; set; }
        public DateTime OrderedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public int PharmacyId { get; set; }

        // Optionally include related data like OrderItems
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }
}
