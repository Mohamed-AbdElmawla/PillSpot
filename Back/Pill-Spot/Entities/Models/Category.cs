using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [MaxLength(250, ErrorMessage = "Category name cannot exceed 250 characters.")]
        public required string Name { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}