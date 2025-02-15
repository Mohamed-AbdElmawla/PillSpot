using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class ProductPharmacyConfiguration : IEntityTypeConfiguration<ProductPharmacy>
    {
        public void Configure(EntityTypeBuilder<ProductPharmacy> builder)
        {
            builder.HasKey(pp => new { pp.ProductID, pp.PharmacyID });

            builder.Property(pp => pp.BatchID)
                .IsRequired();

            builder.Property(pp => pp.Quantity)
                .IsRequired();

            builder.HasOne(pp => pp.Product)
                .WithMany(p => p.ProductPharmacies)
                .HasForeignKey(pp => pp.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Pharmacy)
                .WithMany(p => p.ProductPharmacies)
                .HasForeignKey(pp => pp.PharmacyID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Batch)
                .WithMany()
                .HasForeignKey(pp => pp.BatchID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pp => new { pp.ProductID, pp.PharmacyID })
                .HasDatabaseName("IX_ProductPharmacy_ProductID_PharmacyID");
        }
    }
}