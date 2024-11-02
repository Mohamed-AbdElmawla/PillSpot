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
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(pm => pm.LastUpdated)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasOne(pm => pm.Pharmacy)
                .WithMany(p => p.PharmacyMedicines)
                .HasForeignKey(pm => pm.PharmacyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pm => pm.Medicine)
                .WithMany(m => m.PharmacyMedicine)
                .HasForeignKey(pm => pm.MedicineId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
