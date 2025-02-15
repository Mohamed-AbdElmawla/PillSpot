using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class UserPrescriptionConfiguration : IEntityTypeConfiguration<UserPrescription>
    {
        public void Configure(EntityTypeBuilder<UserPrescription> builder)
        {
            builder.HasKey(up => up.PrescriptionID);

            builder.Property(up => up.UserID)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.HasOne(up => up.Prescription)
                .WithOne()
                .HasForeignKey<UserPrescription>(up => up.PrescriptionID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(up => up.User)
                .WithMany()
                .HasForeignKey(up => up.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(up => up.UserID)
                .HasDatabaseName("IX_UserPrescription_UserID");
        }
    }
}