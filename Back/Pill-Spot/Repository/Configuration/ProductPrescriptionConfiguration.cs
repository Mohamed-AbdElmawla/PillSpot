using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class ProductPrescriptionConfiguration : IEntityTypeConfiguration<ProductPrescription>
    {
        public void Configure(EntityTypeBuilder<ProductPrescription> builder)
        {
            builder.HasKey(pp => new { pp.PrescriptionId, pp.ProductId });

            builder.HasOne(pp => pp.Prescription)
                .WithMany(p => p.ProductPrescriptions)
                .HasForeignKey(pp => pp.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Product)
                .WithMany()
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pp => new { pp.PrescriptionId, pp.ProductId })
                .HasDatabaseName("IX_ProductPrescription_PrescriptionId_ProductId");
        }
    }
}