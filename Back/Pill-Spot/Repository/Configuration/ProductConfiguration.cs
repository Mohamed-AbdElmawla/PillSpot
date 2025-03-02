using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.SubCategoryId)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(true);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.ImageURL)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(p => p.CreatedDate)
                .IsRequired();

            builder.Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(p => p.SubCategory)
                .WithMany(sc => sc.Products)
                .HasForeignKey(p => p.SubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.Name)
                .HasDatabaseName("IX_Product_Name");

            builder.HasIndex(p => p.IsDeleted)
                .HasDatabaseName("IX_Product_IsDeleted");
        }
    }
}