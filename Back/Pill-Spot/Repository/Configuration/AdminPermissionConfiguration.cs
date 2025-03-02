using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class AdminPermissionConfiguration : IEntityTypeConfiguration<AdminPermission>
    {
        public void Configure(EntityTypeBuilder<AdminPermission> builder)
        {
            builder.HasKey(ae => new { ae.AdminID, ae.PermissionID });

            builder.HasOne(ae => ae.Admin)
                .WithMany(ae => ae.AdminPermissions)
                .HasForeignKey(ae => ae.AdminID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ae => ae.Permission)
                .WithMany(a => a.AdminPermissions)
                .HasForeignKey(ae => ae.PermissionID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ae => new { ae.AdminID, ae.PermissionID })
                .HasDatabaseName("IX_AdminPermission_AdminID_PermissionID");
        }
    }
}