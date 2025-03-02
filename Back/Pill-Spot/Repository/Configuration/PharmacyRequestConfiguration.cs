using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Repository.Configuration
{

    public class PharmacyRequestConfiguration : IEntityTypeConfiguration<PharmacyRequest>
    {
        public void Configure(EntityTypeBuilder<PharmacyRequest> builder)
        {
            builder.HasKey(pr => pr.RequestId);

            builder.Property(pr => pr.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(pr => pr.LogoURL)
                   .HasMaxLength(500);

            builder.Property(pr => pr.LicenseId)
                   .IsRequired()
                   .HasMaxLength(450);

            builder.Property(pr => pr.PharmacistLicenseUrl)
            .HasMaxLength(500)
            .IsRequired();

            builder.Property(pr => pr.ContactNumber)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(pr => pr.DaysOpen)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(pr => pr.RequestDate)
                   .IsRequired();

            builder.Property(pr => pr.Status)
                   .IsRequired()
                   .HasDefaultValue(PharmacyRequestStatus.Pending);

            builder.HasOne(pr => pr.User)
                   .WithMany(u => u.PharmacyRequests) 
                   .HasForeignKey(pr => pr.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pr => pr.Location)
                   .WithMany()  // Adjust if Location should navigate to many requests.
                   .HasForeignKey(pr => pr.LocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pr => pr.AdminUser)
                   .WithMany(u => u.ReviewedPharmacyRequests)
                   .HasForeignKey(pr => pr.AdminUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(c => c.UserId)
                .HasDatabaseName("IX_PharmacyRequest_UserId");

            builder.HasIndex(c => c.Status)
                .HasDatabaseName("IX_PharmacyRequest_Status");
        }
    }
}
