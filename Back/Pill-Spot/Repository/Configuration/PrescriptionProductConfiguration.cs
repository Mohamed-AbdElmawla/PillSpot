using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class PrescriptionProductConfiguration : IEntityTypeConfiguration<PrescriptionProduct>
    {
        public void Configure(EntityTypeBuilder<PrescriptionProduct> builder)
        {
            builder.HasKey(pp => new { pp.PrescriptionId, pp.ProductId });

            builder.Property(pp => pp.Quantity)
                .IsRequired();

            builder.Property(pp => pp.Dosage)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(pp => pp.Instructions)
                .HasMaxLength(500)
                .IsUnicode(true);

            builder.HasOne(pp => pp.Prescription)
                .WithMany(p => p.PrescriptionProducts)
                .HasForeignKey(pp => pp.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Product)
                .WithMany()
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
