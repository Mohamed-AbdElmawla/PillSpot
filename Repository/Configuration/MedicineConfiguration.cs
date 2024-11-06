using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.ToTable("Medicines");

            builder.HasKey(m => m.MedicineId);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(m => m.Description)
                .HasMaxLength(1000);

            builder.Property(m => m.ActiveIngredient)
                .HasMaxLength(500);

            builder.Property(m => m.Dosage)
                .HasMaxLength(100);

            builder.Property(m => m.Brand)
                .HasMaxLength(100);

            builder.Property(m => m.Logo)
                .HasMaxLength(255);

            builder.HasMany(m => m.PharmacyMedicine)
                .WithOne(pm => pm.Medicine)
                .HasForeignKey(pm => pm.MedicineId);
        }
    }
}
