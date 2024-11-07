using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class OrderItemForCreationDto
    {
        [Required(ErrorMessage = "UnitPrice is a required field.")]
        public decimal UnitPrice { get; init; }

        [Required(ErrorMessage = "Quantity is a required field.")]
        public int Quantity { get; init; }

        [Required(ErrorMessage = "PharmacyId is a required field.")]
        public int PharmacyId { get; init; }

        [Required(ErrorMessage = "MedicineId is a required field.")]
        public int MedicineId { get; init; }
    }
}