using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class PharmacyProduct
    {
        [Key, Column(Order = 0)]
        public Guid PharmacyId { get; set; }
        [Key, Column(Order = 1)]
        public Guid ProductId { get; set; }

        /*public Guid? BatchId { get; set; }*/

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public int MinimumStockThreshold { get; set; } = 0;
        public DateTime? LastRestocked { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("PharmacyId")]
        public virtual Pharmacy Pharmacy { get; set; }

        /*[ForeignKey("BatchId")]
        public virtual Batch? Batch { get; set; }*/
    }
}