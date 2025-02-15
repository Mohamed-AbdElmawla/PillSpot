using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class OrderItemDto
    {
        public string OrderItemId { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; init; }
        public string OrderId { get; init; }
        public string PharmacyId { get; init; }
        public string MedicineId { get; init; }
    }
}
