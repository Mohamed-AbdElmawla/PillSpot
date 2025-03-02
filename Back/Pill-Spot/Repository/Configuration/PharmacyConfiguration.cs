using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class PharmacyConfiguration : IEntityTypeConfiguration<Pharmacy>
    {
        public void Configure(EntityTypeBuilder<Pharmacy> builder)
        {
            builder.HasKey(p => p.PharmacyId);

            builder.Property(p => p.OwnerId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(true);

            builder.Property(p => p.LogoURL)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(p => p.LicenseId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(p => p.ContactNumber)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false);

            builder.Property(p => p.OpeningTime)
                .IsRequired();

            builder.Property(p => p.ClosingTime)
                .IsRequired();

            builder.Property(p => p.IsOpen24)
                .IsRequired();

            builder.Property(p => p.DaysOpen)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(p => p.CreatedDate)
                .IsRequired();

            builder.Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(p => p.Location)
                .WithMany()
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Owner)
                .WithMany()
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ParentPharmacy)
                .WithMany(p => p.Branches)
                .HasForeignKey(p => p.ParentPharmacyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.Name)
                .HasDatabaseName("IX_Pharmacy_Name");

            builder.HasIndex(p => p.IsDeleted)
                .HasDatabaseName("IX_Pharmacy_IsDeleted");
        }
    }
}