using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IEmailService> _emailService;
        private readonly Lazy<ISerilogService> _serilogService;
        private readonly Lazy<IPermissionService> _permissionService;
        private readonly Lazy<IEmployeePermissionService> _employeePermissionService;
        private readonly Lazy<IAdminPermissionService> _adminPermissionService;
        private readonly Lazy<IAdminService> _adminService;
        private readonly Lazy<IPharmacyService> _pharmacyService;
        private readonly Lazy<IPharmacyRequestService> _pharmacyRequestService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<ISubCategoryService> _subCategoryService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IMedicineService> _medicineService;
        private readonly Lazy<ICosmeticService> _cosmeticService;
        private readonly Lazy<IPharmacyProductService> _pharmacyProductService;
        private readonly Lazy<IPharmacyEmployeeRequestService> _pharmacyEmployeeRequestService;
        private readonly Lazy<IPharmacyEmployeeService> _pharmacyEmployeeService;

        public ServiceManager(IRepositoryManager repositoryManager, ILogger<IServiceManager> logger,
            UserManager<User> userManager, IOptions<JwtConfiguration> configuration, 
            IOptions<EmailConfiguration> emailConfiguration, IMapper mapper, IFileService fileService, 
            Lazy<ISerilogService> serilogService, RoleManager<IdentityRole> roleManager, 
              ILocationService locationService)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration, fileService));
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper, userManager, fileService));
            _emailService = new Lazy<IEmailService>(() => new EmailService(emailConfiguration));
            _serilogService = serilogService;
            _permissionService = new Lazy<IPermissionService>(() => new PermissionService(repositoryManager , mapper));
            _employeePermissionService = new Lazy<IEmployeePermissionService>(() => new EmployeePermissionService(repositoryManager,mapper,userManager));
            _adminPermissionService = new Lazy<IAdminPermissionService>(() => new AdminPermissionService(repositoryManager,mapper,userManager));
            _adminService = new Lazy<IAdminService>(() => new AdminService(repositoryManager,userManager));
            _pharmacyService = new Lazy<IPharmacyService>(() => new PharmacyService(repositoryManager, mapper, userManager, fileService));
            _pharmacyRequestService = new Lazy<IPharmacyRequestService>(() => new PharmacyRequestService(repositoryManager, mapper, userManager, fileService, locationService));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, mapper));
            _subCategoryService = new Lazy<ISubCategoryService>(() => new SubCategoryService(repositoryManager, mapper));
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper, fileService));
            _medicineService = new Lazy<IMedicineService>(() => new MedicineService(repositoryManager, mapper, fileService));
            _cosmeticService = new Lazy<ICosmeticService>(() => new CosmeticService(repositoryManager, mapper, fileService));
            _pharmacyProductService = new Lazy<IPharmacyProductService>(() => new PharmacyProductService(repositoryManager, mapper));
            _pharmacyEmployeeRequestService = new Lazy<IPharmacyEmployeeRequestService>(() => new PharmacyEmployeeRequestService(repositoryManager, mapper,userManager));
            _pharmacyEmployeeService = new Lazy<IPharmacyEmployeeService>(() => new PharmacyEmployeeService(repositoryManager, mapper));
        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IUserService UserService => _userService.Value;
        public IEmailService EmailService => _emailService.Value;
        public ISerilogService SerilogService => _serilogService.Value;
        public IPermissionService PermissionService => _permissionService.Value;
        public IEmployeePermissionService EmployeePermissionService => _employeePermissionService.Value;
        public IAdminPermissionService AdminPermissionService => _adminPermissionService.Value;
        public IAdminService AdminService => _adminService.Value;
        public IPharmacyService PharmacyService => _pharmacyService.Value;
        public IPharmacyRequestService PharmacyRequestService => _pharmacyRequestService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public ISubCategoryService SubCategoryService => _subCategoryService.Value;
        public IProductService ProductService => _productService.Value;
        public IMedicineService MedicineService => _medicineService.Value;
        public ICosmeticService CosmeticService => _cosmeticService.Value;
        public IPharmacyProductService PharmacyProductService => _pharmacyProductService.Value;
        public IPharmacyEmployeeRequestService PharmacyEmployeeRequestService => _pharmacyEmployeeRequestService.Value;
        public IPharmacyEmployeeService PharmacyEmployeeService => _pharmacyEmployeeService.Value;
    }
}