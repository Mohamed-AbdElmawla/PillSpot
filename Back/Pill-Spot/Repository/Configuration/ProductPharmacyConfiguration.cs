using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class ProductPharmacyConfiguration : IEntityTypeConfiguration<ProductPharmacy>
    {
        public void Configure(EntityTypeBuilder<ProductPharmacy> builder)
        {
            builder.HasKey(pp => new { pp.ProductId, pp.PharmacyId });

            builder.Property(pp => pp.BatchId)
                .IsRequired();

            builder.Property(pp => pp.Quantity)
                .IsRequired();

            builder.HasOne(pp => pp.Product)
                .WithMany(p => p.ProductPharmacies)
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Pharmacy)
                .WithMany(p => p.ProductPharmacies)
                .HasForeignKey(pp => pp.PharmacyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Batch)
                .WithMany()
                .HasForeignKey(pp => pp.BatchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pp => new { pp.ProductId, pp.PharmacyId })
                .HasDatabaseName("IX_ProductPharmacy_ProductId_PharmacyId");
        }
    }
}