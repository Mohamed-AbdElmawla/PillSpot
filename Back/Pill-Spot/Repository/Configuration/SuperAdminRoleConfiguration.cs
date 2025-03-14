using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class SuperAdminRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>
            {
                UserId = "superadmin-user-id1", // يجب أن يتطابق مع معرف المستخدم
                RoleId = "superadmin-role-id1" // يجب أن يتطابق مع معرف الدور
            });
        }
    }
}