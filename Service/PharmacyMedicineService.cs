using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class PharmacyMedicineService : IPharmacyMedicineService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public PharmacyMedicineService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<PharmacyMedicineDto> GetMedicines(int pharmacyId, bool trackChanges)
        {
            var pharmacy = _repository.Pharmacy.GetPharmacy(pharmacyId, trackChanges);
            if (pharmacy is null)
                throw new PharmacyNotFoundException(pharmacyId);
            var medicines = _repository.PharmacyMedicine.GetMedicines(pharmacyId, trackChanges);
            var medicinesDto = _mapper.Map<IEnumerable<PharmacyMedicineDto>>(medicines);
            return medicinesDto;
        }
        public PharmacyMedicineDto GetMedicine(int pharmacyId, int medicineId, bool trackChanges)
        {
            var pharmacy = _repository.Pharmacy.GetPharmacy(pharmacyId, trackChanges);
            if (pharmacy is null)
                throw new PharmacyNotFoundException(pharmacyId);
            var medicine = _repository.PharmacyMedicine.GetMedicine(pharmacyId, medicineId, trackChanges);
            if (medicine is null)
                throw new MedicineNotFoundException(medicineId);
            var medicineDto = _mapper.Map<PharmacyMedicineDto>(medicine);
            return medicineDto;
        }
    }
}
