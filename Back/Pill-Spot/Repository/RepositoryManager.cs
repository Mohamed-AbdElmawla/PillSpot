using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
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
        private readonly Lazy<IPharmacyRepository> _pharmacyRepository;
        private readonly Lazy<IPharmacyRequestRepository> _pharmacyRequestRepository;
        private readonly Lazy<ILocationRepository> _locationRepository;
        private readonly Lazy<ICityRepository> _cityRepository;
        private readonly Lazy<IGovernmentRepository> _governmentRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ISubCategoryRepository> _subCategoryRepository;
        public RepositoryManager(RepositoryContext repositoryContext , UserManager<User> userManager)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _permissionRepository = new Lazy<IPermissionRepository>(() => new PermissionRepository(repositoryContext));
            _employeePermissionRepository = new Lazy<IEmployeePermissionRepository>(() => new EmployeePermissionRepository(repositoryContext));
            _adminPermissionRepository = new Lazy<IAdminPermissionRepository>(() => new AdminPermissionRepository(repositoryContext));
            _adminRepository = new Lazy<IAdminRepository>(() => new AdminRepository(userManager));
        }
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IMedicineRepository> _medicineRepository;
        private readonly Lazy<ICosmeticRepository> _cosmeticRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _pharmacyRepository = new Lazy<IPharmacyRepository>(() => new PharmacyRepository(repositoryContext));
            _pharmacyRequestRepository = new Lazy<IPharmacyRequestRepository>(() => new PharmacyRequestRepository(repositoryContext));
            _locationRepository = new Lazy<ILocationRepository>(() => new LocationRepository(repositoryContext));
            _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(repositoryContext));
            _governmentRepository = new Lazy<IGovernmentRepository>(() => new GovernmentRepository(repositoryContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
            _subCategoryRepository = new Lazy<ISubCategoryRepository>(() => new SubCategoryRepository(repositoryContext));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
            _medicineRepository = new Lazy<IMedicineRepository>(() => new MedicineRepository(repositoryContext));
            _cosmeticRepository = new Lazy<ICosmeticRepository>(() => new CosmeticRepository(repositoryContext));
        }

        public IUserRepository UserRepository => _userRepository.Value;
        public IPermissionRepository PermissionRepository => _permissionRepository.Value;
        public IEmployeePermissionRepository EmployeePermissionRepository => _employeePermissionRepository.Value;
        public IAdminPermissionRepository AdminPermissionRepository => _adminPermissionRepository.Value;
        public IAdminRepository AdminRepository => _adminRepository.Value;
        public IPharmacyRepository PharmacyRepository => _pharmacyRepository.Value;
        public IPharmacyRequestRepository PharmacyRequestRepository => _pharmacyRequestRepository.Value;
        public ILocationRepository LocationRepository => _locationRepository.Value;
        public ICityRepository CityRepository => _cityRepository.Value;
        public IGovernmentRepository GovernmentRepository => _governmentRepository.Value;
        public ICategoryRepository CategoryRepository => _categoryRepository.Value;
        public ISubCategoryRepository SubCategoryRepository => _subCategoryRepository.Value;
        public IProductRepository ProductRepository => _productRepository.Value;
        public IMedicineRepository MedicineRepository => _medicineRepository.Value;
        public ICosmeticRepository CosmeticRepository => _cosmeticRepository.Value;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}