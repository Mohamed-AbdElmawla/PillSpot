using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{

    public class Pharmacy
    {
        [Key]
        [Column("PharmacyId")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string State { get; set; }

        [Required]
        [StringLength(20)]
        public string ZipCode { get; set; }

        [Required]
        [Range(-90, 90)]
        public decimal Latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public decimal Longitude { get; set; }

        [Required]
        [StringLength(20)]
        [Phone]
        public string ContactNumber { get; set; }

        [Required]
        public string OpeningHours { get; set; }

        public bool IsOpen24Hours { get; set; }

        // Navigation property for PharmacyMedicines
        public ICollection<PharmacyMedicine> PharmacyMedicines { get; set; }
    }
}
