﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class UserChatConfiguration : IEntityTypeConfiguration<UserChat>
    {
        public void Configure(EntityTypeBuilder<UserChat> builder)
        {
            builder.HasKey(uc => new { uc.UserId, uc.ChatId });

            builder.Property(uc => uc.ImagePath)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(uc => uc.User)
                .WithMany()
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(uc => uc.Chat)
                .WithMany(c => c.UserChats)
                .HasForeignKey(uc => uc.ChatId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(uc => new { uc.UserId, uc.ChatId })
                .HasDatabaseName("IX_UserChat_UserId_ChatId");
        }
    }
}