using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class OrderItem
    {
        [Key]
        public ulong OrderItemID { get; set; }

        [Required(ErrorMessage = "Pharmacy Branch ID is required.")]
        public ulong PharmacyBranchID { get; set; }

        [Required(ErrorMessage = "Product ID is required.")]
        public ulong ProductID { get; set; }

        [Required(ErrorMessage = "Order ID is required.")]
        public ulong OrderID { get; set; }

        [Required(ErrorMessage = "Unit price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than zero.")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("PharmacyBranchID")]
        public virtual Pharmacy PharmacyBranch { get; set; }
    }
}