using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PharmacyMedicineDto
    {
        public int PharmacyId { get; init; }
        public int MedicineId { get; init; }
        public int Quantity { get; init; }
        public decimal Price { get; init; }
        public DateTime LastUpdated { get; init; }
    }
}
