using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Batch
    {
        [Key]
        public ulong BatchId { get; set; }

        [Required(ErrorMessage = "Batch number is required.")]
        [MaxLength(250, ErrorMessage = "Batch number cannot exceed 250 characters.")]
        public string BatchNumber { get; set; }

        [Required(ErrorMessage = "Manufacture date is required.")]
        public DateTime ManufactureDate { get; set; }

        [Required(ErrorMessage = "Expiration date is required.")]
        public DateTime ExpirationDate { get; set; }

        public virtual ICollection<ProductPharmacy> ProductPharmacies { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsDeleted { get; set; } = false; // Default value

        // Concurrency token
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}