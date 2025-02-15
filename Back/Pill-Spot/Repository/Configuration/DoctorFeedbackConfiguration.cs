using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class DoctorFeedbackConfiguration : IEntityTypeConfiguration<DoctorFeedback>
    {
        public void Configure(EntityTypeBuilder<DoctorFeedback> builder)
        {
            builder.HasKey(df => df.FeedbackID);

            builder.Property(df => df.UserID)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.HasOne(df => df.Feedback)
                .WithOne()
                .HasForeignKey<DoctorFeedback>(df => df.FeedbackID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(df => df.Doctor)
                .WithMany()
                .HasForeignKey(df => df.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(df => df.UserID)
                .HasDatabaseName("IX_DoctorFeedback_UserID");
        }
    }
}