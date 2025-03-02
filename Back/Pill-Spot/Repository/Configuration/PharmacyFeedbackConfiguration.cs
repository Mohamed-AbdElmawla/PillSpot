using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class PharmacyFeedbackConfiguration : IEntityTypeConfiguration<PharmacyFeedback>
    {
        public void Configure(EntityTypeBuilder<PharmacyFeedback> builder)
        {
            builder.HasKey(pf => pf.FeedbackId);

            builder.Property(pf => pf.PharmacyId)
                .IsRequired();

            builder.HasOne(pf => pf.Feedback)
                .WithOne()
                .HasForeignKey<PharmacyFeedback>(pf => pf.FeedbackId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pf => pf.Pharmacy)
                .WithMany()
                .HasForeignKey(pf => pf.PharmacyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pf => pf.PharmacyId)
                .HasDatabaseName("IX_PharmacyFeedback_PharmacyId");
        }
    }
}