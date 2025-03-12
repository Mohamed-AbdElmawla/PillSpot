using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ProductIngredient
    {
        [Key, Column(Order = 0)]
        public Guid ProductId { get; set; }

        [Key, Column(Order = 1)]
        public Guid IngredientsId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("IngredientsId")]
        public virtual Ingredient Ingredient { get; set; }
    }
}