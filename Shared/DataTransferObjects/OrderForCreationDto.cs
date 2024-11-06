using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class OrderForCreationDto
    {
        public string Status { get; init; }
        public int LocationId { get; init; }
        public IEnumerable<OrderItemDto> OrderItems { get; init; }
    }
}
