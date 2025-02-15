using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.MessageId);

            builder.Property(m => m.ChatId)
                .IsRequired();

            builder.Property(m => m.SenderId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(m => m.RecipientId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(m => m.Content)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(true);

            builder.Property(m => m.SentDate)
                .IsRequired();

            builder.Property(m => m.IsRead)
                .IsRequired();

            builder.HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Recipient)
                .WithMany()
                .HasForeignKey(m => m.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(m => new { m.ChatId, m.SentDate })
                .HasDatabaseName("IX_Message_ChatId_SentDate");
        }
    }
}