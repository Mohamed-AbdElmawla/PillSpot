using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ProductPharmacy
    {
        [Key, Column(Order = 0)]
        public ulong ProductID { get; set; }

        [Key, Column(Order = 1)]
        public ulong PharmacyID { get; set; }

        [Required(ErrorMessage = "Batch ID is required.")]
        public ulong BatchID { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int Quantity { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("PharmacyID")]
        public virtual Pharmacy Pharmacy { get; set; }

        [ForeignKey("BatchID")]
        public virtual Batch Batch { get; set; }
    }
}