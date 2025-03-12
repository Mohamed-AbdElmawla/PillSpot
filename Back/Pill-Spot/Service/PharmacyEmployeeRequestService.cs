using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class PharmacyEmployeeRequestService : IPharmacyEmployeeRequestService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public PharmacyEmployeeRequestService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task SendRequestAsync(PharmacyEmployeeRequestCreateDto requestDto)
        {
            var requestEntity = _mapper.Map<PharmacyEmployeeRequest>(requestDto);
            requestEntity.Status = RequestStatus.Pending;

            _repository.PharmacyEmployeeRequestRepository.CreateRequestToEmployee(requestEntity);
            await _repository.SaveAsync();
        }
        public async Task ApproveRequestAsync(Guid requestId)
        {
            var request = await _repository.PharmacyEmployeeRequestRepository.GetRequestToEmployeeByIdAsync(requestId, true);

            if (request == null)
                throw new RequestFoundException(requestId);

            if (request.Status != RequestStatus.Pending)
                throw new RequestStatusBadRequestException();

            request.Status = RequestStatus.Approved;

            var employee = new PharmacyEmployee
            {
                UserId = request.UserId,
                PharmacyId = request.PharmacyId,
                Role = "PharmacyEmployee",
                HireDate = DateTime.UtcNow
            };

            _repository.PharmacyEmployeeRepository.AddPharmacyEmployeeAsync(employee);
            await _repository.SaveAsync();
        }
        public async Task RejectRequestAsync(Guid requestId)
        {
            var request = await _repository.PharmacyEmployeeRequestRepository.GetRequestToEmployeeByIdAsync(requestId, true);
            if (request == null)
                throw new KeyNotFoundException($"Request with ID {requestId} not found.");

            request.Status = RequestStatus.Rejected;
            await _repository.SaveAsync();
        }
    }
}