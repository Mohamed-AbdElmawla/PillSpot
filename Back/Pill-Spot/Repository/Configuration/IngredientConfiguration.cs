using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(i => i.IngredientsID);

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true);

            builder.Property(i => i.CreatedDate)
                .IsRequired();

            builder.Property(i => i.IsDeleted)
                .HasDefaultValue(false);

            builder.HasIndex(i => i.Name)
                .HasDatabaseName("IX_Ingredient_Name")
                .IsUnique();

            builder.HasIndex(i => i.IsDeleted)
                .HasDatabaseName("IX_Ingredient_IsDeleted");
        }
    }
}