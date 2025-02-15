using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(sc => sc.SubCategoryID);

            builder.Property(sc => sc.CategoryID)
                .IsRequired();

            builder.Property(sc => sc.Name)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true);

            builder.Property(sc => sc.CreatedDate)
                .IsRequired();

            builder.Property(sc => sc.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(sc => sc.Category)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(sc => sc.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(sc => sc.Name)
                .HasDatabaseName("IX_SubCategory_Name");

            builder.HasIndex(sc => sc.IsDeleted)
                .HasDatabaseName("IX_SubCategory_IsDeleted");
        }
    }
}