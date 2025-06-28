using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.ToTable("Medicines");

            builder.Property(m => m.Dosage)
                .IsRequired()
                .HasColumnType("float");

            builder.Property(m => m.SideEffects)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(true);

            builder.Property(m => m.IsPrescriptionRequired)
                .IsRequired();
        }
    }
}