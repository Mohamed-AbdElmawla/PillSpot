using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class SuperAdminConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();

            var superAdminUser = new User
            {
                Id = "superadmin-user-id1",
                FirstName = "Super",
                LastName = "Admin",
                UserName = "superadmin",
                NormalizedUserName = "SUPERADMIN",
                Email = "superadmin@gmail.com",
                NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumber = "01095832905",
                DateOfBirth = DateTime.Parse("2025-03-13"),
                Gender = 0,
                PasswordHash = hasher.HashPassword(null, "1234Qwer#"),
                SecurityStamp = string.Empty
            };

            builder.HasData(superAdminUser);
        }
    }
}