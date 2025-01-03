using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly Lazy<IMedicineService> _MedicineService;
        private readonly Lazy<IAuthenticationService> _authentication;
        private readonly Lazy<IOrderService> _orderService;
        private readonly Lazy<IDeliveryService> _deliveryService;


        public ServiceManager(IRepositoryManager repositoryManager, ILogger<IServiceManager> logger, UserManager<User> userManager, IConfiguration configuration, IMapper mapper)
        {
            _PharmacyService = new Lazy<IPharmacyService>(() => new PharmacyService(repositoryManager, logger, mapper));
            _PharmacyMedicineService = new Lazy<IPharmacyMedicineService>(() => new PharmacyMedicineService(repositoryManager, logger, mapper));
            _authentication = new Lazy<IAuthenticationService>(() => new AuthenticationService(mapper, userManager, configuration));
            _MedicineService = new Lazy<IMedicineService>(() => new MedicineService(repositoryManager, logger, mapper));
            _orderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager, logger, mapper, userManager));
            _deliveryService = new Lazy<IDeliveryService>(() => new DeliveryService(repositoryManager, logger, mapper, userManager));
        }
        public IPharmacyService PharmacyService => _PharmacyService.Value;
        public IPharmacyMedicineService PharmacyMedicineService => _PharmacyMedicineService.Value;
        public IOrderService OrderService => _orderService.Value;
        public IMedicineService MedicineService => _MedicineService.Value;
        public IAuthenticationService AuthenticationService => _authentication.Value;
        public IDeliveryService DeliveryService => _deliveryService.Value;

    }
}
