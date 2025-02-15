using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ProductIngredient
    {
        [Key, Column(Order = 0)]
        public ulong ProductID { get; set; }

        [Key, Column(Order = 1)]
        public ulong IngredientsID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("IngredientsID")]
        public virtual Ingredient Ingredient { get; set; }
    }
}