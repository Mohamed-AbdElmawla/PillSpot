using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class PharmacyConfiguration : IEntityTypeConfiguration<Pharmacy>
    {
        public void Configure(EntityTypeBuilder<Pharmacy> builder)
        {
            builder.ToTable("Pharmacies");

            builder.HasKey(p => p.PharmacyId);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Logo)
                .HasMaxLength(500);

            builder.Property(p => p.ContactNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.OpeningHours)
                .IsRequired();

            builder.Property(p => p.IsOpen24Hours)
                .HasDefaultValue(false);

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(p => p.LicenseId)
                .HasMaxLength(50);

            builder.HasOne(p => p.Location)
                .WithMany(l => l.Pharmacies)
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PharmacyMedicines)
                .WithOne(pm => pm.Pharmacy)
                .HasForeignKey(pm => pm.PharmacyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
