using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class UserNotificationConfiguration : IEntityTypeConfiguration<UserNotification>
    {
        public void Configure(EntityTypeBuilder<UserNotification> builder)
        {
            builder.HasKey(un => new { un.ReceiverId, un.NotificationId });

            builder.HasOne(un => un.Receiver)
                .WithMany()
                .HasForeignKey(un => un.ReceiverId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(un => un.Notification)
                .WithMany()
                .HasForeignKey(un => un.NotificationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(un => new { un.ReceiverId, un.NotificationId })
                .HasDatabaseName("IX_UserNotification_ReceiverId_NotificationId");
        }
    }
}