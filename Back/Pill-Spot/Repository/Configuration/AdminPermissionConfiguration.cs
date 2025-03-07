using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class AdminPermissionConfiguration : IEntityTypeConfiguration<AdminPermission>
    {
        public void Configure(EntityTypeBuilder<AdminPermission> builder)
        {
            builder.HasKey(ae => new { ae.AdminId, ae.PermissionId });

            builder.HasOne(ae => ae.Admin)
                .WithMany(ae => ae.AdminPermissions)
                .HasForeignKey(ae => ae.AdminId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ae => ae.Permission)
                .WithMany(a => a.AdminPermissions)
                .HasForeignKey(ae => ae.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ae => new { ae.AdminId, ae.PermissionId })
                .HasDatabaseName("IX_AdminPermission_AdminId_PermissionId");
        }
    }
}