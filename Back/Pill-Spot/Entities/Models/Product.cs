using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Product
    {
        [Key]
        public ulong ProductId { get; set; }

        [Required(ErrorMessage = "SubCategory ID is required.")]
        public int SubCategoryId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(250, ErrorMessage = "Name cannot exceed 250 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public double Price { get; set; }

        [MaxLength(500, ErrorMessage = "Image URL cannot exceed 500 characters.")]
        public string ImageURL { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedDate { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();

        public virtual ICollection<ProductPharmacy> ProductPharmacies { get; set; } = new List<ProductPharmacy>();

        [Required]
        public bool IsDeleted { get; set; } = false;

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}