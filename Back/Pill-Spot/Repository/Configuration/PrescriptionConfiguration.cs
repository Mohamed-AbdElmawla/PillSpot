using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(p => p.PrescriptionId);

            builder.Property(p => p.CreatedDate)
                .IsRequired();

            builder.Property(p => p.FilePath)
                .HasMaxLength(500)
                .IsUnicode(true);

            builder.Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            builder.HasIndex(p => p.IsDeleted)
                .HasDatabaseName("IX_Prescription_IsDeleted");
        }
    }
}