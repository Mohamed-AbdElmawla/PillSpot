using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class DoctorFeedbackConfiguration : IEntityTypeConfiguration<DoctorFeedback>
    {
        public void Configure(EntityTypeBuilder<DoctorFeedback> builder)
        {
            builder.HasKey(df => df.FeedbackId);

            builder.Property(df => df.UserId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.HasOne(df => df.Feedback)
                .WithOne()
                .HasForeignKey<DoctorFeedback>(df => df.FeedbackId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(df => df.Doctor)
                .WithMany()
                .HasForeignKey(df => df.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(df => df.UserId)
                .HasDatabaseName("IX_DoctorFeedback_UserId");
        }
    }
}