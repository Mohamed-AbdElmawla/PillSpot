using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class SearchHistoryConfiguration : IEntityTypeConfiguration<SearchHistory>
    {
        public void Configure(EntityTypeBuilder<SearchHistory> builder)
        {
            builder.ToTable("SearchHistories");

            builder.HasKey(sh => sh.SearchId);

            builder.Property(sh => sh.SearchTerm)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(sh => sh.SearchedAt)
                .IsRequired();

            builder.HasOne(sh => sh.User)
                .WithMany(u => u.SearchHistories)
                .HasForeignKey(sh => sh.UserId);
        }
    }
}
