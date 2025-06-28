using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "user-role-id",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "doctor-role-id",
                    Name = "Doctor",
                    NormalizedName = "DOCTOR"
                },
                new IdentityRole
                {
                    Id = "pharmacy-owner-role-id",
                    Name = "PharmacyOwner",
                    NormalizedName = "PHARMACYOWNER"
                },
                new IdentityRole
                {
                    Id = "pharmacy-manager-role-id",
                    Name = "PharmacyManager",
                    NormalizedName = "PHARMACYMANAGER"
                },
                new IdentityRole
                {
                    Id = "pharmacy-employee-role-id",
                    Name = "PharmacyEmployee",
                    NormalizedName = "PHARMACYEMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "superadmin-role-id1",
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                },
                new IdentityRole
                {
                    Id = "admin-role-id",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );
        }
    }
}
