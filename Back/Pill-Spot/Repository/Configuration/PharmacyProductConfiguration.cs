using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class PharmacyProductConfiguration : IEntityTypeConfiguration<PharmacyProduct>
    {
        public void Configure(EntityTypeBuilder<PharmacyProduct> builder)
        {
            builder.HasKey(pp => new { pp.ProductId, pp.PharmacyId });

            builder.Property(pp => pp.BatchId)
                .IsRequired();

            builder.Property(pp => pp.Quantity)
                .IsRequired();

            builder.HasOne(pp => pp.Product)
                .WithMany(p => p.PharmacyProducts)
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Pharmacy)
                .WithMany(p => p.PharmacyProducts)
                .HasForeignKey(pp => pp.PharmacyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Batch)
                .WithMany()
                .HasForeignKey(pp => pp.BatchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pp => new { pp.ProductId, pp.PharmacyId })
                .HasDatabaseName("IX_PharmacyProduct_ProductId_PharmacyId");
        }
    }
}