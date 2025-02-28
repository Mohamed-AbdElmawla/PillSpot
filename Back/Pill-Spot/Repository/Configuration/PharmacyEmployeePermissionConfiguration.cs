using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class PharmacyEmployeePermissionConfiguration : IEntityTypeConfiguration<PharmacyEmployeePermission>
    {
        public void Configure(EntityTypeBuilder<PharmacyEmployeePermission> builder)
        {
            builder.HasKey(pe => new { pe.EmployeeID, pe.PermissionID });

            builder.HasOne(pe => pe.PharmacyEmployee)
                .WithMany(pe => pe.PharmacyEmployeePermissions)
                .HasForeignKey(pe => pe.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pe => pe.Permission)
                .WithMany(p => p.PharmacyEmployeePermissions)
                .HasForeignKey(pe => pe.PermissionID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(pe => new { pe.EmployeeID, pe.PermissionID })
                .HasDatabaseName("IX_PharmacyEmployeePermission_EmployeeID_PermissionID");
        }
    }
}
