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

        [Required(ErrorMessage = "LocationId is a required field.")]
        public string LocationId { get; init; }

        [Required(ErrorMessage = "OrderItems is a required field.")]
        public IEnumerable<OrderItemForCreationDto> OrderItems { get; init; }
    }
}
