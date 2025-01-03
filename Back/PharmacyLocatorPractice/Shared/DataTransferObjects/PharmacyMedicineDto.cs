using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PharmacyMedicineDto
    {
        public decimal Price { get; set; }
        public DateTime LastUpdated { get; set; }
        public int Quantity { get; set; }
        public string PharmacyId { get; set; }
        public string MedicineId { get; set; }

    }
}
