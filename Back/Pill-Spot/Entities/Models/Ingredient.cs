using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Ingredient
    {
        [Key]
        public ulong IngredientsId { get; set; }

        [Required(ErrorMessage = "Ingredient name is required.")]
        [MaxLength(250, ErrorMessage = "Ingredient name cannot exceed 250 characters.")]
        public string Name { get; set; }

        public virtual ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}