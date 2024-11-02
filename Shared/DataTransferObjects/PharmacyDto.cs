using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PharmacyDto
    {

        public int Id { get; init; }
        public string Name { get; init; }
        public string Address { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string ZipCode { get; init; }
        public decimal Latitude { get; init; }
        public decimal Longitude { get; init; }
        public string ContactNumber { get; init; }
        public string OpeningHours { get; init; }
        public bool IsOpen24Hours { get; init; }
        public string? Logo { get; init; }
        public IEnumerable<PharmacyMedicineDto> PharmacyMedicines { get; init; }
    }
}
