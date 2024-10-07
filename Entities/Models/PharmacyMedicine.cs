using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PharmacyMedicine
    {
        [Key]
        [Column("PharmacyMedicineId")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Pharmacy")]
        public int PharmacyId { get; set; }

        [Required]
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; } = DateTime.Now;

        // Navigation properties
        public Pharmacy Pharmacy { get; set; }
        public Medicine Medicine { get; set; }
    }
}
