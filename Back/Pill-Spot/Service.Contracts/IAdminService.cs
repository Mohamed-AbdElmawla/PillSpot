using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAdminService
    {
        Task BulkManageUsersAsync(BulkUserManagementDto dto);
        Task AssignUserRoleAsync(AssignUserRoleDto dto);
      // Task<byte[]> ExportUserDataAsync();
    }
}
