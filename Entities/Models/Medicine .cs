using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Medicine
    {
        [Key]
        [Column("MedicineId")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Brand { get; set; }

        [Required]
        [StringLength(50)]
        public string Dosage { get; set; }

        // Navigation property for PharmacyMedicines
        public ICollection<PharmacyMedicine> PharmacyMedicines { get; set; }
    }
}
