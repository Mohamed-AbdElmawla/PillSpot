using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class OrderForCreationDto
    {
        public string UserId { get; init; }
        public int LocationId { get; init; }
        public DateTime OrderedAt { get; init; } = DateTime.Now;
        public decimal TotalPrice { get; init; }
        public string Status { get; init; }
        public int PharmacyId { get; init; }
        public IEnumerable<OrderItemForCreationDto> OrderItems { get; init; }
    }
}
