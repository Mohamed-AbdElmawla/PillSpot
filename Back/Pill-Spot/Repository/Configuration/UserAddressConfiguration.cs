using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("UserAddresses");

            builder.HasKey(a => a.AddressId);

            builder.Property(a => a.AddressId)
                .IsRequired(); // remove HasDefaultValueSql("NEWID()") because MySQL doesn't support it properly

            builder.Property(a => a.UserId)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(a => a.Label)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.LocationId)
                .IsRequired();

            builder.Property(a => a.IsDefault)
                .HasDefaultValue(false);

            builder.HasOne(a => a.User)
                .WithMany(u => u.UserAddresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Location)
                .WithMany()
                .HasForeignKey(a => a.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => a.UserId);
            builder.HasIndex(a => new { a.UserId, a.IsDefault });
        }
    }
}
