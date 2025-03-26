using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class PharmacyEmployeeRequestConfiguration : IEntityTypeConfiguration<PharmacyEmployeeRequest>
    {
        public void Configure(EntityTypeBuilder<PharmacyEmployeeRequest> builder)
        {
            builder.HasKey(per => per.RequestId);

            builder.Property(per => per.UserId)
                .IsRequired();

            builder.Property(per => per.RequesterId) 
             .IsRequired();

            builder.Property(per => per.PharmacyId)
                .IsRequired();

            builder.Property(per => per.Status)
                .IsRequired()
                .HasDefaultValue(RequestStatus.Pending);

            builder.Property(per => per.RequestDate)
                .IsRequired();

            builder.HasOne(per => per.User)
                .WithMany()
                .HasForeignKey(per => per.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(per => per.Requester)
                .WithMany()
                .HasForeignKey(per => per.RequesterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(per => per.Pharmacy)
                .WithMany()
                .HasForeignKey(per => per.PharmacyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
