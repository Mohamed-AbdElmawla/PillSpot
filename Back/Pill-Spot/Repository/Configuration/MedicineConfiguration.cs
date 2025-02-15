using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasBaseType<Product>();

            builder.Property(m => m.Manufacturer)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true);

            builder.Property(m => m.Dosage)
                .IsRequired()
                .HasColumnType("float");

            builder.Property(m => m.SideEffects)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(true);

            builder.Property(m => m.IsPrescriptionRequired)
                .IsRequired();

            builder.HasIndex(m => m.Manufacturer)
                .HasDatabaseName("IX_Medicine_Manufacturer");
        }
    }
}