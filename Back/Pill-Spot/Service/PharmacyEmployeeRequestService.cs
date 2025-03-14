using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class PharmacyEmployeeRequestService : IPharmacyEmployeeRequestService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public PharmacyEmployeeRequestService(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task SendRequestAsync(PharmacyEmployeeRequestCreateDto requestDto, bool trackChanges)
        {
            var user = await _userManager.FindByIdAsync(requestDto.UserId);
            if (user == null)
                throw new UserNotFoundException(requestDto.UserId);

            var existingPindingRequest = await _repository.PharmacyEmployeeRequestRepository
                .GetRequestToEmployeeByStatusAsync(requestDto.UserId , requestDto.PharmacyId , RequestStatus.Pending , trackChanges);

            if (existingPindingRequest != null)
                throw new DuplicateBadRequestException();

            var existingApprovedRequest = await _repository.PharmacyEmployeeRequestRepository
                .GetRequestToEmployeeByStatusAsync(requestDto.UserId, requestDto.PharmacyId,RequestStatus.Approved, trackChanges);

            if (existingApprovedRequest != null)
                throw new EmployeeApprovedBadRequestException();

            var requestEntity = _mapper.Map<PharmacyEmployeeRequest>(requestDto);
            requestEntity.Status = RequestStatus.Pending;

            _repository.PharmacyEmployeeRequestRepository.CreateRequestToEmployee(requestEntity);
            await _repository.SaveAsync();
        }
        public async Task ApproveRequestAsync(Guid requestId, bool trackChanges)
        {
            var request = await _repository.PharmacyEmployeeRequestRepository.GetRequestToEmployeeByIdAsync(requestId, trackChanges);

            if (request == null)
                throw new RequestFoundException(requestId);

            if (request.Status != RequestStatus.Pending)
                throw new RequestStatusBadRequestException();

            request.Status = RequestStatus.Approved;

            var employee = _mapper.Map<PharmacyEmployee>(request);

            _repository.PharmacyEmployeeRepository.AddPharmacyEmployeeAsync(employee);
            await _repository.SaveAsync();
        }
        public async Task RejectRequestAsync(Guid requestId, bool trackChanges)
        {
            var request = await _repository.PharmacyEmployeeRequestRepository.GetRequestToEmployeeByIdAsync(requestId, trackChanges);
            if (request == null)
                throw new EmployeeRequestFoundException(requestId);

            request.Status = RequestStatus.Rejected;
            await _repository.SaveAsync();
        }
    }
}