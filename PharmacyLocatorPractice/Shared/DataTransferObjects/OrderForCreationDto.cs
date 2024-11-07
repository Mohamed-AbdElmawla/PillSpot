using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class OrderForCreationDto
    {
        public string Status { get; init; }

        [Required(ErrorMessage = "LocationId is a required field.")]
        public int LocationId { get; init; }

        [Required(ErrorMessage = "OrderItems is a required field.")]
        public IEnumerable<OrderItemDto> OrderItems { get; init; }
    }
}
