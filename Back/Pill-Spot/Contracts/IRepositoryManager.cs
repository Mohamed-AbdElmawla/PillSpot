using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; } 
        IPermissionRepository PermissionRepository { get; }
        IEmployeePermissionRepository EmployeePermissionRepository { get;}
        IAdminPermissionRepository AdminPermissionRepository { get; }
        IAdminRepository AdminRepository { get; }
        Task SaveAsync();
    }
}
