using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PharmacyForCreationDto
    (
        string Name,
        string Address,
        string City,
        string State,
        string ZipCode,
        decimal Latitude,
        decimal Longitude,
        string ContactNumber,
        string OpeningHours,
        bool IsOpen24Hours,
        string? Logo, 
        IEnumerable<PharmacyMedicineForCreationDto> PharmacyMedicines
    );
}
