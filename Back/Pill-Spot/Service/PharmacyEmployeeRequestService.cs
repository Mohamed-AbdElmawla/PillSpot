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
        private readonly RoleManager<IdentityRole> _roleManager;

        public PharmacyEmployeeRequestService(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager, INotificationService notificationService, RoleManager<IdentityRole> roleManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _notificationService = notificationService;
            _roleManager = roleManager;
        }

        public async Task SendRequestAsync(Guid PharmacyId, PharmacyEmployeeRequestCreateDto requestDto, string userId, bool trackChanges)
        {
            var user = await _userManager.FindByNameAsync(requestDto.UserName);
            if (user == null)
                throw new UserNotFoundException(requestDto.UserName);

            var existingPindingRequest = await _repository.PharmacyEmployeeRequestRepository
                .GetRequestToEmployeeByStatusAsync(user.Id, PharmacyId, RequestStatus.Pending, trackChanges);

            if (existingPindingRequest.Count() > 0)
                throw new DuplicateBadRequestException();

            var existingApprovedRequest = await _repository.PharmacyEmployeeRequestRepository
                .GetRequestToEmployeeByStatusAsync(user.Id, PharmacyId, RequestStatus.Approved, trackChanges);

            if (existingApprovedRequest.Count() > 0)
                throw new EmployeeApprovedBadRequestException();

            
            var roleExists = await _roleManager.RoleExistsAsync(requestDto.RoleName);
            if (!roleExists)
                throw new RoleNameNotFoundException(requestDto.RoleName);

            
            if (requestDto.Permissions != null)
            {
                foreach (var permissionName in requestDto.Permissions)
                {
                    var permission = await _repository.PermissionRepository.GetByNameAsync(permissionName,false);
                    if (permission == null)
                        throw new PermissionNotFoundException(permission.PermissionId);
                }
            }


            var requestEntity = _mapper.Map<PharmacyEmployeeRequest>(requestDto);
            requestEntity.UserId = user.Id;
            requestEntity.RequesterId = userId;
            requestEntity.Permissions = requestDto.Permissions != null ? string.Join(", ", requestDto.Permissions) : null;
            requestEntity.PharmacyId = PharmacyId;

            _repository.PharmacyEmployeeRequestRepository.CreateRequestToEmployee(requestEntity);
            
            // Use transaction to ensure data consistency
            await _repository.BeginTransactionAsync();
            try
            {
                await _repository.SaveAsync();
                
                // Get pharmacy name for notification
                var pharmacy = await _repository.PharmacyRepository.GetPharmacyAsync(PharmacyId, false);
                var requester = await _userManager.FindByIdAsync(userId);
                
                // Prepare notification data
                var notificationData = JsonSerializer.Serialize(new { 
                    requestId = requestEntity.RequestId,
                    userId = user.Id,
                    userName = user.UserName,
                    requesterId = userId,
                    requesterName = requester?.UserName,
                    pharmacyId = PharmacyId,
                    pharmacyName = pharmacy?.Name,
                    status = "Pending",
                    timestamp = DateTime.UtcNow
                });

                await _repository.CommitTransactionAsync();
                
                // Send notifications outside of the transaction to avoid DbContext conflicts
                await SendEmployeeRequestNotificationsAfterTransactionAsync(
                    user, requestEntity, pharmacy, requester, notificationData);
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }
        
        private async Task SendEmployeeRequestNotificationsAfterTransactionAsync(
            User user, PharmacyEmployeeRequest requestEntity, Pharmacy pharmacy, User requester, string notificationData)
        {
            try
            {
                // Notify the user about the request
                await _notificationService.SendRequestStatusUpdateNotificationAsync(
                    user.Id,
                    requestEntity.RequestId,
                    "Pending",
                    $"You have received an employee request from {requester?.UserName ?? "Pharmacy Manager"} for {pharmacy?.Name ?? "Pharmacy"}. Please review and respond."
                );

                // Notify pharmacy managers about the new request
                await _notificationService.SendNotificationToPharmacyManagersAsync(
                    requestEntity.PharmacyId,
                    "New Employee Request",
                    $"A new employee request has been sent to {user.UserName} for {pharmacy?.Name ?? "Pharmacy"}",
                    NotificationType.RequestUpdate,
                    notificationData
                );

                // Notify admins about the new employee request
                await _notificationService.SendNotificationToRolesAsync(
                    new[] { "Admin", "SuperAdmin" },
                    "New Pharmacy Employee Request",
                    $"A new employee request has been sent to {user.UserName} for {pharmacy?.Name ?? "Pharmacy"} by {requester?.UserName ?? "Pharmacy Manager"}",
                    NotificationType.RequestUpdate,
                    notificationData
                );
            }
            catch (Exception ex)
            {
                // Log the error but don't fail the main operation
                Console.WriteLine($"Failed to send employee request notifications: {ex.Message}");
            }
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

            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                throw new UserNotFoundException(user.Id);

            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if (role == null)
                throw new RoleNameNotFoundException(request.RoleName);

            //Create PharmacyEmployee
            var employee = _mapper.Map<PharmacyEmployee>(request);
            _repository.PharmacyEmployeeRepository.AddPharmacyEmployee(employee);

            //Add Role to PharmacyEmployeeRoles
            var employeeRole = new PharmacyEmployeeRole
            {
                EmployeeId = employee.EmployeeId,
                PharmacyId = request.PharmacyId,
                RoleId = role.Id
            };
            _repository.PharmacyEmployeeRoleRepository.AddPharmacyEmployeeRole(employeeRole);

            //Add Permissions
            var permissions = request.Permissions?
                .Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            if (permissions != null)
            {
                foreach (var permissionName in permissions)
                {
                    var permission = await _repository.PermissionRepository.GetByNameAsync(permissionName,false);
                    if (permission != null)
                    {
                        var employeePermission = new PharmacyEmployeePermission
                        {
                            EmployeeId = employee.EmployeeId,
                            PermissionId = permission.PermissionId
                        };
                        _repository.EmployeePermissionRepository.AssignPermissionToEmployeeAsync(employeePermission);
                    }
                }
            }

            // Use transaction to ensure data consistency
            await _repository.BeginTransactionAsync();
            try
            {
                await _repository.SaveAsync();
                
                // Get pharmacy and user details for notifications
                var pharmacy = await _repository.PharmacyRepository.GetPharmacyAsync(request.PharmacyId, false);
                var requester = await _userManager.FindByIdAsync(request.RequesterId);
                
                // Prepare notification data
                var notificationData = JsonSerializer.Serialize(new { 
                    requestId = request.RequestId,
                    userId = request.UserId,
                    userName = user?.UserName,
                    requesterId = request.RequesterId,
                    requesterName = requester?.UserName,
                    pharmacyId = request.PharmacyId,
                    pharmacyName = pharmacy?.Name,
                    status = "Approved",
                    timestamp = DateTime.UtcNow
                });

                await _repository.CommitTransactionAsync();
                
                // Send notifications outside of the transaction to avoid DbContext conflicts
                await SendEmployeeApprovalNotificationsAfterTransactionAsync(
                    request, user, pharmacy, requester, notificationData);
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }
        
        private async Task SendEmployeeApprovalNotificationsAfterTransactionAsync(
            PharmacyEmployeeRequest request, User user, Pharmacy pharmacy, User requester, string notificationData)
        {
            try
            {
                // Notify the requester (pharmacy manager) about approval
                await _notificationService.SendEmployeeRequestNotificationAsync(
                    request.RequesterId,
                    request.RequestId,
                    pharmacy?.Name ?? "Pharmacy",
                    user?.UserName ?? "User",
                    "Approved"
                );

                // Notify admins about the employee request approval
                await _notificationService.SendNotificationToRolesAsync(
                    new[] { "Admin", "SuperAdmin" },
                    "Pharmacy Employee Request Approved",
                    $"Employee request for {user?.UserName ?? "User"} at {pharmacy?.Name ?? "Pharmacy"} has been approved",
                    NotificationType.RequestUpdate,
                    notificationData
                );

                // Notify the user about their approval
                await _notificationService.SendRequestStatusUpdateNotificationAsync(
                    request.UserId,
                    request.RequestId,
                    "Approved",
                    $"Your employee request for {pharmacy?.Name ?? "Pharmacy"} has been approved! You are now an employee."
                );
            }
            catch (Exception ex)
            {
                // Log the error but don't fail the main operation
                Console.WriteLine($"Failed to send employee approval notifications: {ex.Message}");
            }
        }

        public async Task RejectRequestAsync(Guid requestId, string currentUserId, bool trackChanges)
        {
            var request = await _repository.PharmacyEmployeeRequestRepository.GetRequestToEmployeeByIdAsync(requestId, trackChanges);
            if (request == null)
                throw new EmployeeRequestFoundException(requestId);

            if (request.UserId != currentUserId)
                throw new UnauthorizedApprovalException();

            request.Status = RequestStatus.Rejected;
            
            // Use transaction to ensure data consistency
            await _repository.BeginTransactionAsync();
            try
            {
                await _repository.SaveAsync();
                
                // Get pharmacy and user details for notifications
                var pharmacy = await _repository.PharmacyRepository.GetPharmacyAsync(request.PharmacyId, false);
                var user = await _userManager.FindByIdAsync(request.UserId);
                var requester = await _userManager.FindByIdAsync(request.RequesterId);
                
                // Prepare notification data
                var notificationData = JsonSerializer.Serialize(new { 
                    requestId = request.RequestId,
                    userId = request.UserId,
                    userName = user?.UserName,
                    requesterId = request.RequesterId,
                    requesterName = requester?.UserName,
                    pharmacyId = request.PharmacyId,
                    pharmacyName = pharmacy?.Name,
                    status = "Rejected",
                    timestamp = DateTime.UtcNow
                });

                await _repository.CommitTransactionAsync();
                
                // Send notifications outside of the transaction to avoid DbContext conflicts
                await SendEmployeeRejectionNotificationsAfterTransactionAsync(
                    request, user, pharmacy, requester, notificationData);
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }
        
        private async Task SendEmployeeRejectionNotificationsAfterTransactionAsync(
            PharmacyEmployeeRequest request, User user, Pharmacy pharmacy, User requester, string notificationData)
        {
            try
            {
                // Notify the requester (pharmacy manager) about rejection
                await _notificationService.SendEmployeeRequestNotificationAsync(
                    request.RequesterId,
                    request.RequestId,
                    pharmacy?.Name ?? "Pharmacy",
                    user?.UserName ?? "User",
                    "Rejected"
                );

                // Notify admins about the employee request rejection
                await _notificationService.SendNotificationToRolesAsync(
                    new[] { "Admin", "SuperAdmin" },
                    "Pharmacy Employee Request Rejected",
                    $"Employee request for {user?.UserName ?? "User"} at {pharmacy?.Name ?? "Pharmacy"} has been rejected",
                    NotificationType.RequestUpdate,
                    notificationData
                );

                // Notify the user about their rejection
                await _notificationService.SendRequestStatusUpdateNotificationAsync(
                    request.UserId,
                    request.RequestId,
                    "Rejected",
                    $"Your employee request for {pharmacy?.Name ?? "Pharmacy"} has been rejected."
                );
            }
            catch (Exception ex)
            {
                // Log the error but don't fail the main operation
                Console.WriteLine($"Failed to send employee rejection notifications: {ex.Message}");
            }
        }

        public async Task<(IEnumerable<PharmacyEmployeeRequestDto> pharmacyEmployeeRequests, MetaData metaData)> GetRequestsAsync(EmployeesRequestParameters employeeRequestParameters, string userId, bool trackChanges)
        {
            var requestsWithMetaData = await _repository.PharmacyEmployeeRequestRepository.GetRequestsAsync(employeeRequestParameters, userId, trackChanges);

            var pharmacyEmployeeRequestsDto = _mapper.Map<IEnumerable<PharmacyEmployeeRequestDto>>(requestsWithMetaData);

            return (pharmacyEmployeeRequests: pharmacyEmployeeRequestsDto, metaData: requestsWithMetaData.MetaData);
        }
    }
}