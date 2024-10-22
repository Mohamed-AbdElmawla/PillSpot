using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record MedicineForCreationDto
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string ActiveIngredient { get; init; }
        public string Dosage { get; init; }
        public string Brand { get; init; }
    }
}
