using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public required string UserId { get; set; }

        [Required(ErrorMessage = "Location ID is required.")]
        public Guid LocationId { get; set; }

        [Required(ErrorMessage = "Total price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total price must be greater than zero.")]
        public double TotalPrice { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? PaymentDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public int Status { get; set; }

        [Required(ErrorMessage = "Payment method is required.")]
        public int PaymentMethod { get; set; }

        [Required]
        public bool IsSuccessful { get; set; }

        [Required(ErrorMessage = "Currency is required.")]
        public int Currency { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}