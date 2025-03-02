using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class UserPrescriptionConfiguration : IEntityTypeConfiguration<UserPrescription>
    {
        public void Configure(EntityTypeBuilder<UserPrescription> builder)
        {
            builder.HasKey(up => up.PrescriptionId);

            builder.Property(up => up.UserId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.HasOne(up => up.Prescription)
                .WithOne()
                .HasForeignKey<UserPrescription>(up => up.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(up => up.User)
                .WithMany()
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(up => up.UserId)
                .HasDatabaseName("IX_UserPrescription_UserId");
        }
    }
}