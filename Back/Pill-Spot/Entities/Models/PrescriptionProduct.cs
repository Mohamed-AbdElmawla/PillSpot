using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class PrescriptionProduct
    {
        [Key, Column(Order = 0)]
        public Guid PrescriptionId { get; set; }

        [Key, Column(Order = 1)]
        public Guid ProductId { get; set; }
        
        public int Quantity { get; set; }

        public string Dosage { get; set; }

        public string Instructions { get; set; }

        [ForeignKey("PrescriptionId")]
        public virtual Prescription Prescription { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}