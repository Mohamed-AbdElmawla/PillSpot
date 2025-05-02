using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class PharmacyCartDto
    {
        public Guid PharmacyId { get; init; }
        public string PharmacyName { get; init; }
        public decimal Subtotal { get; init; }
        public decimal DeliveryFee { get; init; }
        public IEnumerable<CartItemDto> Items { get; init; }
    }
}
