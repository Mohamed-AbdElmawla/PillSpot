using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class DoctorPrescriptionConfiguration : IEntityTypeConfiguration<DoctorPrescription>
    {
        public void Configure(EntityTypeBuilder<DoctorPrescription> builder)
        {
            builder.HasKey(dp => dp.PrescriptionId);

            builder.Property(dp => dp.DoctorId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(dp => dp.UserId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(dp => dp.Instructions)
                .HasMaxLength(500)
                .IsUnicode(true);

            builder.HasOne(dp => dp.Prescription)
                .WithOne()
                .HasForeignKey<DoctorPrescription>(dp => dp.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(dp => dp.Doctor)
                .WithMany()
                .HasForeignKey(dp => dp.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dp => dp.User)
                .WithMany()
                .HasForeignKey(dp => dp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(dp => dp.DoctorId)
                .HasDatabaseName("IX_DP_DocId");

            builder.HasIndex(dp => dp.UserId)
                .HasDatabaseName("IX_DP_UsrId");
        }
    }
}