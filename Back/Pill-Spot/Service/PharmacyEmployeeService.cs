using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    public class PharmacyEmployeeService : IPharmacyEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public PharmacyEmployeeService(IRepositoryManager repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<PharmacyEmployeeProfileDto> pharmacies, MetaData metaData)> GetUserPharmaciesAsync(string userName, EmployeesParameters employeesParameters, bool trackChanges)
        {
            var user = await _repository.UserRepository.GetUserAsync(userName, trackChanges);

            if (user == null)
                throw new UserNotFoundException(userName);
            var pharmaciesWithMetaData = await _repository.PharmacyEmployeeRepository.GetUserPharmaciesAsync(user.Id, employeesParameters, trackChanges);

            var pharmaciesDto = _mapper.Map<IEnumerable<PharmacyEmployeeProfileDto>>(pharmaciesWithMetaData);

            return (pharmacies: pharmaciesDto, metaData: pharmaciesWithMetaData.MetaData);
        }
    }
}
