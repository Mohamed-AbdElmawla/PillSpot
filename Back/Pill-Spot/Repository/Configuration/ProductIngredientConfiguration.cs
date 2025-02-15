using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class ProductIngredientConfiguration : IEntityTypeConfiguration<ProductIngredient>
    {
        public void Configure(EntityTypeBuilder<ProductIngredient> builder)
        {
            builder.HasKey(pi => new { pi.ProductID, pi.IngredientsID });

            builder.HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientsID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(pi => new { pi.ProductID, pi.IngredientsID })
                .HasDatabaseName("IX_ProductIngredient_ProductID_IngredientsID");
        }
    }
}