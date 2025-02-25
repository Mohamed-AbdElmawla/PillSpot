using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    public class GovernmentService : IGovernmentService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GovernmentService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<GovernmentDto> governments, MetaData metaData)> GetAllGovernmentsAsync(GovernmentRequestParameters governmentRequestParameters, bool trackChanges)
        {
            var governmentsWithMetaData = await _repository.GovernmentRepository.GetAllGovernmentsAsync(governmentRequestParameters, trackChanges);

            var governmentDtos = _mapper.Map<IEnumerable<GovernmentDto>>(governmentsWithMetaData);

            return (governments: governmentDtos, metaData: governmentsWithMetaData.MetaData);
        }

        public async Task<GovernmentDto> GetGovernmentByIdAsync(Guid governmentId, bool trackChanges)
        {
            var governmentEntity = await _repository.GovernmentRepository.GetGovernmentByIdAsync(governmentId, trackChanges);

            if (governmentEntity == null)
                throw new GovernmentNotFoundException(governmentId);

            return _mapper.Map<GovernmentDto>(governmentEntity);
        }

        public async Task<Guid> CreateGovernmentAsync(GovernmentForCreationDto government, bool trackChanges)
        {
            var governmentEntity = await _repository.GovernmentRepository.GetGovernmentByNameAsync(government.GovernmentName, trackChanges);

            if (governmentEntity == null)
            {
                governmentEntity = _mapper.Map<Government>(government);

                _repository.GovernmentRepository.CreateGovernment(governmentEntity);
            }
            return governmentEntity.GovernmentId;
        }

        public async Task UpdateGovernmentAsync(Guid governmentId, GovernmentForCreationDto government, bool trackChanges)
        {
            var governmentEntity = await _repository.GovernmentRepository.GetGovernmentByIdAsync(governmentId, trackChanges);

            if (governmentEntity == null)
                throw new GovernmentNotFoundException(governmentId);

            _mapper.Map(government, governmentEntity);

            await _repository.SaveAsync();
        }

        public async Task DeleteGovernmentAsync(Guid governmentId, bool trackChanges)
        {
            var governmentEntity = await _repository.GovernmentRepository.GetGovernmentByIdAsync(governmentId, trackChanges);

            if (governmentEntity == null)
                throw new GovernmentNotFoundException(governmentId);

            _repository.GovernmentRepository.DeleteGovernment(governmentEntity);

            await _repository.SaveAsync();
        }

    }
}
