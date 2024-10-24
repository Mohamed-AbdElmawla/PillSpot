using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class OrderForCreationDto
    {
        public string UserId { get; set; }
        public int LocationId { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public int PharmacyId { get; set; }
        public IEnumerable<OrderItemForCreationDto> OrderItems { get; set; }
    }
}
