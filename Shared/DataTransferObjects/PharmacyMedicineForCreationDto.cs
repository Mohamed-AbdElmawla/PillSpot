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
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int PharmacyId { get; set; }
        public int MedicineId { get; set; }
    }
}
