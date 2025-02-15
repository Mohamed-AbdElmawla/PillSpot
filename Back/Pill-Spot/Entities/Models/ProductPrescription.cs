using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ProductPrescription
    {
        [Key, Column(Order = 0)]
        public ulong PrescriptionID { get; set; }

        [Key, Column(Order = 1)]
        public ulong ProductID { get; set; }

        [ForeignKey("PrescriptionID")]
        public virtual Prescription Prescription { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}