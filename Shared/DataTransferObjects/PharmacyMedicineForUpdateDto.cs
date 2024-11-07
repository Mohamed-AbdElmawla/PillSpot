using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PharmacyMedicineForUpdateDto
    {
        [Required(ErrorMessage = "MedicineId is required")]
        public int MedicineId { get; init; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; init; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; init; }

    };
}
