using AutoMapper;
using Contracts;
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
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger,IMapper mapper)
        {
            _PharmacyService = new Lazy<IPharmacyService>(() => new PharmacyService(repositoryManager, logger,mapper));
            _PharmacyMedicineService = new Lazy<IPharmacyMedicineService>(() => new PharmacyMedicineService(repositoryManager, logger,mapper));
        }
        public IPharmacyService PharmacyService => _PharmacyService.Value;
        public IPharmacyMedicineService PharmacyMedicineService => _PharmacyMedicineService.Value;

    }
}
