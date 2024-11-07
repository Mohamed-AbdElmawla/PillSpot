using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
   public record PharmacyMedicineForCreationDto
    {
        [Required(ErrorMessage = "Price is a required field.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity is a required field.")]
        public int Quantity { get; set; }
        
        [Required(ErrorMessage = "PharmacyId is a required field.")]
        public int PharmacyId { get; set; }

        [Required(ErrorMessage = "MedicineId is a required field.")]
        public int MedicineId { get; set; }
    }
}
