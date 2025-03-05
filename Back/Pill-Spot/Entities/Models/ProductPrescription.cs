using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ProductPrescription
    {
        [Key, Column(Order = 0)]
        public ulong PrescriptionId { get; set; }

        [Key, Column(Order = 1)]
        public ulong ProductId { get; set; }

        [ForeignKey("PrescriptionId")]
        public virtual Prescription Prescription { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}