using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class DoctorPrescriptionConfiguration : IEntityTypeConfiguration<DoctorPrescription>
    {
        public void Configure(EntityTypeBuilder<DoctorPrescription> builder)
        {
            builder.HasKey(dp => dp.PrescriptionID);

            builder.Property(dp => dp.DoctorId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(dp => dp.UserID)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(dp => dp.Instructions)
                .HasMaxLength(500)
                .IsUnicode(true);

            builder.HasOne(dp => dp.Prescription)
                .WithOne()
                .HasForeignKey<DoctorPrescription>(dp => dp.PrescriptionID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(dp => dp.Doctor)
                .WithMany()
                .HasForeignKey(dp => dp.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dp => dp.User)
                .WithMany()
                .HasForeignKey(dp => dp.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(dp => dp.DoctorId)
                .HasDatabaseName("IX_DP_DocId");

            builder.HasIndex(dp => dp.UserID)
                .HasDatabaseName("IX_DP_UsrID");
        }
    }
}