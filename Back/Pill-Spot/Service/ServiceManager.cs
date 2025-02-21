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
        public ServiceManager(IRepositoryManager repositoryManager, ILogger<IServiceManager> logger,
            UserManager<User> userManager, IOptions<JwtConfiguration> configuration, IOptions<EmailConfiguration> emailConfiguration, IMapper mapper, IFileService fileService)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration, fileService));
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper, userManager));
            _emailService = new Lazy<IEmailService>(() => new EmailService(emailConfiguration));
        }
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IUserService UserService => _userService.Value;
        public IEmailService EmailService => _emailService.Value;

    }
}
