using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Pharmacy
    {
        public int PharmacyId { get; set; }
        public string Name { get; set; }
        public string? Logo { get; set; }
        public string ContactNumber { get; set; }
        public string OpeningHours { get; set; }
        public bool IsOpen24Hours { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LicenseID { get; set; }
        public int LocationId { get; set; }

        public Location Location { get; set; }
        public ICollection<PharmacyMedicine> PharmacyMedicines { get; set; }
    }
}
