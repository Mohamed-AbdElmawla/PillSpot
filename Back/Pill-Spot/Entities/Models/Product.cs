using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public enum ProductType { Medicine, Cosmetic }
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "SubCategory ID is required.")]
        public Guid SubCategoryId { get; set; }

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
        public string? ImageURL { get; set; }

        [Required(ErrorMessage = "Usage instructions are required.")]
        [MaxLength(500, ErrorMessage = "Usage instructions cannot exceed 500 characters.")]
        public string UsageInstructions { get; set; }

        [Required(ErrorMessage = "Manufacturer is required.")]
        [MaxLength(250, ErrorMessage = "Manufacturer cannot exceed 250 characters.")]
        public required string Manufacturer { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedDate { get; set; }
        public ProductType Type { get; set; }

        public virtual SubCategory? SubCategory { get; set; }

        public virtual ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();

        public virtual ICollection<PharmacyProduct> PharmacyProducts { get; set; } = new List<PharmacyProduct>();

        [Required]
        public bool IsDeleted { get; set; } = false;

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [Required]
        public int StockQuantity { get; set; }
    }
}