using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class PharmacyMedicineConfiguration : IEntityTypeConfiguration<PharmacyMedicine>
    {
        public void Configure(EntityTypeBuilder<PharmacyMedicine> builder)
        {
            builder.ToTable("PharmacyMedicines");

            builder.HasKey(pm => new { pm.PharmacyId, pm.MedicineId });

            builder.Property(pm => pm.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(pm => pm.Quantity)
                .IsRequired();

            builder.Property(pm => pm.LastUpdated)
                .IsRequired();

            builder.HasOne(pm => pm.Pharmacy)
                .WithMany(p => p.PharmacyMedicines)
                .HasForeignKey(pm => pm.PharmacyId);

            builder.HasOne(pm => pm.Medicine)
                .WithMany(m => m.PharmacyMedicine)
                .HasForeignKey(pm => pm.MedicineId);
        }
    }
}
