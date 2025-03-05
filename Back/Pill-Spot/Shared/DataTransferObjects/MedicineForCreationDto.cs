using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record MedicineForCreationDto : ProductForCreationDto
    {
        public string Manufacturer { get; init; }
        public float Dosage { get; init; }
        public string SideEffects { get; init; }
        public bool IsPrescriptionRequired { get; init; }
    }
}
