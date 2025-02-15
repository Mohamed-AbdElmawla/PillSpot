using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.UserID);

            builder.Property(d => d.LicenseID)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(d => d.Rate)
                .IsRequired()
                .HasColumnType("decimal(3,2)");

            builder.Property(d => d.CreatedDate)
                .IsRequired();

            builder.Property(d => d.IsDeleted)
                .HasDefaultValue(false);

            builder.HasIndex(d => d.LicenseID)
                .HasDatabaseName("IX_Doctor_LicenseID")
                .IsUnique();
            builder.HasIndex(c => c.IsDeleted)
                .HasDatabaseName("IX_Doctor_IsDeleted");

            builder.HasOne(d => d.User)
                .WithOne()
                .HasForeignKey<Doctor>(d => d.UserID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}