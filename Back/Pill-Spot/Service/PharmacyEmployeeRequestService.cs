using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace Service
{
    public sealed class PharmacyEmployeeRequestService : IPharmacyEmployeeRequestService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;

        public PharmacyEmployeeRequestService(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager, INotificationService notificationService)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _notificationService = notificationService;
        }

        public async Task SendRequestAsync(PharmacyEmployeeRequestCreateDto requestDto, string userId, bool trackChanges)
        {
            var user = await _userManager.FindByEmailAsync(requestDto.Email);
            if (user == null)
                throw new UserNotFoundException(requestDto.Email);

            var existingPindingRequest = await _repository.PharmacyEmployeeRequestRepository
                .GetRequestToEmployeeByStatusAsync(user.Id, requestDto.PharmacyId, RequestStatus.Pending, trackChanges);

            if (existingPindingRequest.Count() > 0)
                throw new DuplicateBadRequestException();

            var existingApprovedRequest = await _repository.PharmacyEmployeeRequestRepository
                .GetRequestToEmployeeByStatusAsync(user.Id, requestDto.PharmacyId, RequestStatus.Approved, trackChanges);

            if (existingApprovedRequest.Count() > 0)
                throw new EmployeeApprovedBadRequestException();

            var requestEntity = _mapper.Map<PharmacyEmployeeRequest>(requestDto);
            requestEntity.UserId = user.Id;
            requestEntity.RequesterId = userId;
            requestEntity.Status = RequestStatus.Pending;

            _repository.PharmacyEmployeeRequestRepository.CreateRequestToEmployee(requestEntity);
            await _repository.SaveAsync();

            // Get pharmacy name for notification
            var pharmacy = await _repository.PharmacyRepository.GetPharmacyAsync(requestDto.PharmacyId, false);
            var requester = await _userManager.FindByIdAsync(userId);

            // Notify the user about the request
            await _notificationService.SendRequestStatusUpdateNotificationAsync(
                user.Id,
                requestEntity.RequestId,
                "Pending",
                $"You have received an employee request from {requester?.UserName ?? "Pharmacy Manager"} for {pharmacy?.Name ?? "Pharmacy"}. Please review and respond."
            );

            // Notify pharmacy managers about the new request
            await _notificationService.SendNotificationToPharmacyManagersAsync(
                requestDto.PharmacyId,
                "New Employee Request",
                $"A new employee request has been sent to {user.UserName} for {pharmacy?.Name ?? "Pharmacy"}",
                NotificationType.RequestUpdate,
                JsonSerializer.Serialize(new { 
                    requestId = requestEntity.RequestId,
                    userId = user.Id,
                    userName = user.UserName,
                    requesterId = userId,
                    requesterName = requester?.UserName,
                    pharmacyId = requestDto.PharmacyId,
                    pharmacyName = pharmacy?.Name,
                    status = "Pending",
                    timestamp = DateTime.UtcNow
                })
            );
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

            // Get pharmacy and user details for notifications
            var pharmacy = await _repository.PharmacyRepository.GetPharmacyAsync(request.PharmacyId, false);
            var user = await _userManager.FindByIdAsync(request.UserId);
            var requester = await _userManager.FindByIdAsync(request.RequesterId);

            // Notify the requester (pharmacy manager) about approval
            await _notificationService.SendEmployeeRequestNotificationAsync(
                request.RequesterId,
                request.RequestId,
                pharmacy?.Name ?? "Pharmacy",
                user?.UserName ?? "User",
                "Approved"
            );

            // Notify the user about their approval
            await _notificationService.SendRequestStatusUpdateNotificationAsync(
                request.UserId,
                request.RequestId,
                "Approved",
                $"Your employee request for {pharmacy?.Name ?? "Pharmacy"} has been approved! You are now an employee."
            );
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

            // Get pharmacy and user details for notifications
            var pharmacy = await _repository.PharmacyRepository.GetPharmacyAsync(request.PharmacyId, false);
            var user = await _userManager.FindByIdAsync(request.UserId);
            var requester = await _userManager.FindByIdAsync(request.RequesterId);

            // Notify the requester (pharmacy manager) about rejection
            await _notificationService.SendEmployeeRequestNotificationAsync(
                request.RequesterId,
                request.RequestId,
                pharmacy?.Name ?? "Pharmacy",
                user?.UserName ?? "User",
                "Rejected"
            );

            // Notify the user about their rejection
            await _notificationService.SendRequestStatusUpdateNotificationAsync(
                request.UserId,
                request.RequestId,
                "Rejected",
                $"Your employee request for {pharmacy?.Name ?? "Pharmacy"} has been rejected."
            );
        }

        public async Task<(IEnumerable<PharmacyEmployeeRequestDto> pharmacyEmployeeRequests, MetaData metaData)> GetRequestsAsync(EmployeesRequestParameters employeeRequestParameters, string userId, bool trackChanges)
        {
            var requestsWithMetaData = await _repository.PharmacyEmployeeRequestRepository.GetRequestsAsync(employeeRequestParameters, userId, trackChanges);

            var pharmacyEmployeeRequestsDto = _mapper.Map<IEnumerable<PharmacyEmployeeRequestDto>>(requestsWithMetaData);

            return (pharmacyEmployeeRequests: pharmacyEmployeeRequestsDto, metaData: requestsWithMetaData.MetaData);
        }
    }
}