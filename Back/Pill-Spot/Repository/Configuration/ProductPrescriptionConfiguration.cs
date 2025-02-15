using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class ProductPrescriptionConfiguration : IEntityTypeConfiguration<ProductPrescription>
    {
        public void Configure(EntityTypeBuilder<ProductPrescription> builder)
        {
            builder.HasKey(pp => new { pp.PrescriptionID, pp.ProductID });

            builder.HasOne(pp => pp.Prescription)
                .WithMany(p => p.ProductPrescriptions)
                .HasForeignKey(pp => pp.PrescriptionID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Product)
                .WithMany()
                .HasForeignKey(pp => pp.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pp => new { pp.PrescriptionID, pp.ProductID })
                .HasDatabaseName("IX_ProductPrescription_PrescriptionID_ProductID");
        }
    }
}