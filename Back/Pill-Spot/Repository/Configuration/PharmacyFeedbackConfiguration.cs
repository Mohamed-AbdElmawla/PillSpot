using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class PharmacyFeedbackConfiguration : IEntityTypeConfiguration<PharmacyFeedback>
    {
        public void Configure(EntityTypeBuilder<PharmacyFeedback> builder)
        {
            builder.HasKey(pf => pf.FeedbackID);

            builder.Property(pf => pf.PharmacyID)
                .IsRequired();

            builder.HasOne(pf => pf.Feedback)
                .WithOne()
                .HasForeignKey<PharmacyFeedback>(pf => pf.FeedbackID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pf => pf.Pharmacy)
                .WithMany()
                .HasForeignKey(pf => pf.PharmacyID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pf => pf.PharmacyID)
                .HasDatabaseName("IX_PharmacyFeedback_PharmacyID");
        }
    }
}