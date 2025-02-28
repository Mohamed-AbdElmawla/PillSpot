using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IPermissionRepository> _permissionRepository;
        private readonly Lazy<IEmployeePermissionRepository> _employeePermissionRepository;
        private readonly Lazy<IAdminPermissionRepository> _adminPermissionRepository;
        private readonly Lazy<IAdminRepository> _adminRepository;
        public RepositoryManager(RepositoryContext repositoryContext , UserManager<User> userManager)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _permissionRepository = new Lazy<IPermissionRepository>(() => new PermissionRepository(repositoryContext));
            _employeePermissionRepository = new Lazy<IEmployeePermissionRepository>(() => new EmployeePermissionRepository(repositoryContext));
            _adminPermissionRepository = new Lazy<IAdminPermissionRepository>(() => new AdminPermissionRepository(repositoryContext));
            _adminRepository = new Lazy<IAdminRepository>(() => new AdminRepository(userManager));
        }
        public IUserRepository UserRepository => _userRepository.Value;
        public IPermissionRepository PermissionRepository => _permissionRepository.Value;
        public IEmployeePermissionRepository EmployeePermissionRepository => _employeePermissionRepository.Value;
        public IAdminPermissionRepository AdminPermissionRepository => _adminPermissionRepository.Value;
        public IAdminRepository AdminRepository => _adminRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
