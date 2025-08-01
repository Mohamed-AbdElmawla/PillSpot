﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class SupportConfiguration : IEntityTypeConfiguration<Support>
    {
        public void Configure(EntityTypeBuilder<Support> builder)
        {
            builder.HasKey(s => s.SupportId);

            builder.Property(s => s.UserId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(s => s.Type)
                .IsRequired();

            builder.Property(s => s.Priority)
                .IsRequired();

            builder.Property(s => s.IssueTitle)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(s => s.IssueDetails)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(true);

            builder.Property(s => s.AssignedTo)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(s => s.Status)
                .IsRequired();

            builder.Property(s => s.CreatedDate)
                .IsRequired();

            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(s => s.UserId)
                .HasDatabaseName("IX_Support_UserId");

            builder.HasIndex(s => s.IsDeleted)
                .HasDatabaseName("IX_Support_IsDeleted");
        }
    }
}