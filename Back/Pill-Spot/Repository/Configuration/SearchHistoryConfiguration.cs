using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class SearchHistoryConfiguration : IEntityTypeConfiguration<SearchHistory>
    {
        public void Configure(EntityTypeBuilder<SearchHistory> builder)
        {
            builder.HasKey(sh => sh.SearchId);

            builder.Property(sh => sh.SearchTerm)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(true);

            builder.Property(sh => sh.SearchedAt)
                .IsRequired();

            builder.Property(sh => sh.UserId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(sh => sh.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(sh => sh.User)
                .WithMany()
                .HasForeignKey(sh => sh.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(sh => sh.UserId)
                .HasDatabaseName("IX_SearchHistory_UserId");

            builder.HasIndex(sh => sh.IsDeleted)
                .HasDatabaseName("IX_SearchHistory_IsDeleted");
        }
    }
}