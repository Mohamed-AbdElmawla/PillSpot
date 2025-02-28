using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task BulkManageUsersAsync(BulkUserManagementDto dto)
        {
            foreach (var userId in dto.UserIds)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    switch (dto.Action)
                    {
                        case "Activate":
                            user.LockoutEnd = null;
                            break;
                        case "Deactivate":
                            user.LockoutEnd = DateTimeOffset.MaxValue;
                            break;
                        case "Delete":
                            await _userManager.DeleteAsync(user);
                            break;
                    }
                    await _userManager.UpdateAsync(user);
                }
            }
        }

        public async Task AssignUserRoleAsync(AssignUserRoleDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user != null)
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, dto.Role);
            }
        }

        //public async Task<byte[]> ExportUserDataAsync()
        //{
        //    var users = _userManager.Users.ToList();
        //    var userDtos = users.Select(u => new UserExportDto
        //    {
        //        Id = u.Id,
        //        Username = u.UserName!,
        //        Email = u.Email!,
        //        Role = _userManager.GetRolesAsync(u).Result.FirstOrDefault() ?? "No Role",
        //        IsActive = u.LockoutEnd == null || u.LockoutEnd <= DateTimeOffset.Now
        //    }).ToList();

        //    using var memoryStream = new MemoryStream();
        //    using var writer = new StreamWriter(memoryStream, Encoding.UTF8);
        //    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        //    await csv.WriteRecordsAsync(userDtos);
        //    await writer.FlushAsync();
        //    return memoryStream.ToArray();
        //}
    }
}
