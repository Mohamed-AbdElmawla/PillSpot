using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Pharmacy
    {
        [Key]
        [Column("PharmacyId")]
        public int PharmacyId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Logo { get; set; }

        [Required]
        [StringLength(20)]
        [Phone]
        public string ContactNumber { get; set; }
        public int LocationId { get; set; }
        [Required]
        public string OpeningHours { get; set; }
        public bool IsOpen24Hours { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LicenseId { get; set; }

        public Location Location { get; set; }
        public ICollection<PharmacyMedicine> PharmacyMedicines { get; set; }
    }
}
