using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly Lazy<IPharmacyService> _PharmacyService;
        private readonly Lazy<IPharmacyMedicineService> _PharmacyMedicineService;
        private readonly Lazy<IAuthenticationService> _authentication;
        private readonly Lazy<IOrderService> _orderService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, UserManager<User> userManager,IConfiguration configuration, IMapper mapper)
        {
            _PharmacyService = new Lazy<IPharmacyService>(() => new PharmacyService(repositoryManager, logger,mapper));
            _PharmacyMedicineService = new Lazy<IPharmacyMedicineService>(() => new PharmacyMedicineService(repositoryManager, logger,mapper));
            _authentication = new Lazy<IAuthenticationService>(() => new AuthenticationService(mapper, userManager, configuration));
            _orderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager, logger, mapper));
        }
        public IPharmacyService PharmacyService => _PharmacyService.Value;
        public IPharmacyMedicineService PharmacyMedicineService => _PharmacyMedicineService.Value;
        public IOrderService OrderService => _orderService.Value;
        public IAuthenticationService AuthenticationService => _authentication.Value;

    }
}
