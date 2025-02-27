using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductID);

            builder.Property(p => p.SubCategoryID)
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
                .HasForeignKey(p => p.SubCategoryID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Medicine)
        .WithOne(m => m.Product)
        .HasForeignKey<Medicine>(m => m.ProductID)
        .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Cosmetic)
                .WithOne(c => c.Product)
                .HasForeignKey<Cosmetic>(c => c.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.Name)
                .HasDatabaseName("IX_Product_Name");

            builder.HasIndex(p => p.IsDeleted)
                .HasDatabaseName("IX_Product_IsDeleted");
        }
    }
}