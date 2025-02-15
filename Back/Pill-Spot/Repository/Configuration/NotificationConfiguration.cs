using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.NotificationID);

            builder.Property(n => n.ActorId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(n => n.CreatedDate)
                .IsRequired();

            builder.Property(n => n.Content)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(true);

            builder.Property(n => n.IsNotified)
                .IsRequired();

            builder.Property(n => n.IsBroadcast)
                .IsRequired();

            builder.Property(n => n.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(n => n.Actor)
                .WithMany()
                .HasForeignKey(n => n.ActorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(n => n.ActorId)
                .HasDatabaseName("IX_Notification_ActorId");

            builder.HasIndex(n => n.IsDeleted)
                .HasDatabaseName("IX_Notification_IsDeleted");
        }
    }
}