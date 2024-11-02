using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class OrderItemDto
    {
        public int OrderItemId { get; init; }
        public int MedicineId { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; init; }
    }
}
