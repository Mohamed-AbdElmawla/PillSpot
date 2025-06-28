using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    public sealed class PharmacyEmployeeRequestService : IPharmacyEmployeeRequestService
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
        public async Task SendRequestAsync(PharmacyEmployeeRequestCreateDto requestDto, string userId,bool trackChanges)
        {
            var user = await _userManager.FindByEmailAsync(requestDto.Email);
            if (user == null)
                throw new UserNotFoundException(requestDto.Email);

            var existingPindingRequest = await _repository.PharmacyEmployeeRequestRepository
                .GetRequestToEmployeeByStatusAsync(user.Id , requestDto.PharmacyId , RequestStatus.Pending , trackChanges);

            if (existingPindingRequest.Count() > 0)
                throw new DuplicateBadRequestException();

            var existingApprovedRequest = await _repository.PharmacyEmployeeRequestRepository
                .GetRequestToEmployeeByStatusAsync(user.Id, requestDto.PharmacyId,RequestStatus.Approved, trackChanges);

            if (existingApprovedRequest.Count() > 0)
                throw new EmployeeApprovedBadRequestException();

            var requestEntity = _mapper.Map<PharmacyEmployeeRequest>(requestDto);
            requestEntity.UserId = user.Id;
            requestEntity.RequesterId = userId;
            requestEntity.Status = RequestStatus.Pending;

            _repository.PharmacyEmployeeRequestRepository.CreateRequestToEmployee(requestEntity);
            await _repository.SaveAsync();
        }
        public async Task ApproveRequestAsync(Guid requestId, string currentUserId, bool trackChanges)
        {
            var request = await _repository.PharmacyEmployeeRequestRepository.GetRequestToEmployeeByIdAsync(requestId, trackChanges);

            if (request == null)
                throw new RequestFoundException(requestId);

            if (request.UserId != currentUserId)
                throw new UnauthorizedApprovalException();

            if (request.Status != RequestStatus.Pending)
                throw new RequestStatusBadRequestException();

            request.Status = RequestStatus.Approved;

            var employee = _mapper.Map<PharmacyEmployee>(request);

            _repository.PharmacyEmployeeRepository.AddPharmacyEmployee(employee);
            await _repository.SaveAsync();
        }
        public async Task RejectRequestAsync(Guid requestId, string currentUserId, bool trackChanges)
        {
            var request = await _repository.PharmacyEmployeeRequestRepository.GetRequestToEmployeeByIdAsync(requestId, trackChanges);
            if (request == null)
                throw new EmployeeRequestFoundException(requestId);
            
            if (request.UserId != currentUserId)
                throw new UnauthorizedApprovalException();

            request.Status = RequestStatus.Rejected;
            await _repository.SaveAsync();
        }
        public async Task<(IEnumerable<PharmacyEmployeeRequestDto> pharmacyEmployeeRequests, MetaData metaData)> GetRequestsAsync(EmployeesRequestParameters employeeRequestParameters,string userId, bool trackChanges)
        {
            var requestsWithMetaData = await _repository.PharmacyEmployeeRequestRepository.GetRequestsAsync(employeeRequestParameters,userId, trackChanges);

            var pharmacyEmployeeRequestsDto = _mapper.Map<IEnumerable<PharmacyEmployeeRequestDto>>(requestsWithMetaData);

            return (pharmacyEmployeeRequests: pharmacyEmployeeRequestsDto, metaData: requestsWithMetaData.MetaData);
        }
    }
}