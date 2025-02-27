using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {

        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IEmailService> _emailService;
        private readonly Lazy<IPharmacyService> _pharmacyService;
        private readonly Lazy<IPharmacyRequestService> _pharmacyRequestService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<ISubCategoryService> _subCategoryService;
        public ServiceManager(IRepositoryManager repositoryManager, ILogger<IServiceManager> logger,
            UserManager<User> userManager, IOptions<JwtConfiguration> configuration,
            IOptions<EmailConfiguration> emailConfiguration, IMapper mapper, IFileService fileService, ILocationService locationService)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration, fileService));
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper, userManager, fileService));
            _emailService = new Lazy<IEmailService>(() => new EmailService(emailConfiguration));
            _pharmacyService = new Lazy<IPharmacyService>(() => new PharmacyService(repositoryManager, mapper, userManager, fileService));
            _pharmacyRequestService = new Lazy<IPharmacyRequestService>(() => new PharmacyRequestService(repositoryManager, mapper, userManager, fileService, locationService));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, mapper));
            _subCategoryService = new Lazy<ISubCategoryService>(() => new SubCategoryService(repositoryManager, mapper));
        }
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IUserService UserService => _userService.Value;
        public IEmailService EmailService => _emailService.Value;
        public IPharmacyService PharmacyService => _pharmacyService.Value;
        public IPharmacyRequestService PharmacyRequestService => _pharmacyRequestService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public ISubCategoryService SubCategoryService => _subCategoryService.Value;
    }
}
