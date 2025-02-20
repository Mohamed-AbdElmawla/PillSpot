using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.ProfilePictureUrl)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(u => u.DateOfBirth)
                .IsRequired();

            builder.Property(u => u.Gender)
                .IsRequired();

            builder.Property(u => u.CreatedDate)
                .IsRequired();

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(u => u.LastName)
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(u => u.RowVersion)
                .IsRowVersion();

            builder.HasOne(u => u.Location)
                .WithMany()
                .HasForeignKey(u => u.LocationID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(u => u.LocationID)
                .HasDatabaseName("IX_User_LocationID");
        }
    }
}