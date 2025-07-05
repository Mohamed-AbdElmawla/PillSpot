﻿using AutoMapper;
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
    internal class PharmacyRequestService : IPharmacyRequestService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly ILocationService _locationService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly INotificationService _notificationService;

        public PharmacyRequestService(IRepositoryManager repository, IMapper mapper,
            UserManager<User> userManager, IFileService fileService, ILocationService locationService, 
            RoleManager<IdentityRole> roleManager, INotificationService notificationService)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
            _locationService = locationService;
            _roleManager = roleManager;
            _notificationService = notificationService;
        }
        public async Task SubmitRequestAsync(string userName, PharmacyRequestCreateDto pharmacyRequestCreateDto, bool trackChanges)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                throw new UserNotFoundException(userName);

            var approvedRequest = await _repository.PharmacyRequestRepository
                .GetByStatusAsync(user.Id, PharmacyRequestStatus.Approved, trackChanges);

            if (approvedRequest != null && approvedRequest.Count() >= 2)
                throw new PharmacyRequestExcededBadRequestException();

            var pendingRequest = await _repository.PharmacyRequestRepository.GetByStatusAsync(user.Id, PharmacyRequestStatus.Pending, trackChanges);
            var pharmacyRequest = _mapper.Map<PharmacyRequest>(pharmacyRequestCreateDto);

            pharmacyRequest.UserId = user.Id;

            if (pharmacyRequestCreateDto.logo != null)
                pharmacyRequest.LogoURL = await _fileService.SaveFileAsync(pharmacyRequestCreateDto.logo, "Logos");

            if (pharmacyRequestCreateDto.PharmacistLicense != null)
                pharmacyRequest.PharmacistLicenseUrl = await _fileService.SaveFileAsync(pharmacyRequestCreateDto.PharmacistLicense, "PharmacistLicenses");

            if (pendingRequest != null && pendingRequest.Any())
            {   
                var pendingPharmacyRequest = pendingRequest.FirstOrDefault();
                if(pendingPharmacyRequest != null)
                _repository.PharmacyRequestRepository.DeletePharmacyRequest(pendingPharmacyRequest);
            }
            pharmacyRequest.LocationId = await _locationService.CreateLocationAsync(pharmacyRequestCreateDto.Location, trackChanges);
            pharmacyRequest.Location = null;
            _repository.PharmacyRequestRepository.CreatePharmacyRequest(pharmacyRequest);
            
            // Use transaction to ensure data consistency
            await _repository.BeginTransactionAsync();
            try
            {
                await _repository.SaveAsync();
                
                // Prepare notification data
                var notificationData = JsonSerializer.Serialize(new { 
                    requestId = pharmacyRequest.RequestId,
                    userName,
                    pharmacyName = pharmacyRequest.Name,
                    status = "Pending",
                    timestamp = DateTime.UtcNow
                });

                // Send notifications after database transaction is committed
                await _repository.CommitTransactionAsync();
                
                // Send notifications outside of the transaction to avoid DbContext conflicts
                await SendNotificationsAfterTransactionAsync(user.Id, pharmacyRequest, userName, notificationData);
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }
        
        private async Task SendNotificationsAfterTransactionAsync(string userId, PharmacyRequest pharmacyRequest, string userName, string notificationData)
        {
            try
            {
                // Notify admins about new pharmacy request
                await _notificationService.SendNotificationToRolesAsync(
                    new[] { "Admin", "SuperAdmin" },
                    "New Pharmacy Request",
                    $"A new pharmacy request has been submitted by {userName} for '{pharmacyRequest.Name}'",
                    NotificationType.RequestUpdate,
                    notificationData
                );

                // Notify the user about their request submission
                await _notificationService.SendPharmacyRequestNotificationAsync(
                    userId,
                    pharmacyRequest.RequestId,
                    pharmacyRequest.Name,
                    "Submitted"
                );
            }
            catch (Exception ex)
            {
                // Log the error but don't fail the main operation
                Console.WriteLine($"Failed to send notifications: {ex.Message}");
            }
        }
        public async Task ApproveRequestAsync(Guid requestId, bool trackChanges)
        {
            var request = await _repository.PharmacyRequestRepository.GetByIdAsync(requestId, trackChanges);

            if (request == null)
                throw new PharmacyRequestNotFoundException(requestId);

            if (!request.Status.Equals(PharmacyRequestStatus.Pending))
                throw new PharmacyRequestAlreadyReviewedBadRequestException(requestId, request.Status.ToString());
            request.Status = PharmacyRequestStatus.Approved;

            var pharmacy = _mapper.Map<Pharmacy>(request);

            _repository.PharmacyRepository.CreatePharmacy(pharmacy);

            var newEmployee = new PharmacyEmployee
            {
                PharmacyId = pharmacy.PharmacyId,
                UserId = request.UserId
            };

            _repository.PharmacyEmployeeRepository.AddPharmacyEmployee(newEmployee);
            
            var role = await _roleManager.FindByNameAsync("PharmacyOwner");
            if (role == null)
                throw new Exception($"Role PharmacyOwner not found.");

            var pharmacyEmployeeRole = new PharmacyEmployeeRole
            {
                EmployeeId = newEmployee.EmployeeId,
                PharmacyId = pharmacy.PharmacyId, 
                RoleId = role.Id
            };

            _repository.PharmacyEmployeeRoleRepository.AddPharmacyEmployeeRole(pharmacyEmployeeRole);

            // Use transaction to ensure data consistency
            await _repository.BeginTransactionAsync();
            try
            {
                await _repository.SaveAsync();
                
                // Prepare notification data
                var notificationData = JsonSerializer.Serialize(new { 
                    requestId = request.RequestId,
                    pharmacyName = pharmacy.Name,
                    userId = request.UserId,
                    status = "Approved",
                    timestamp = DateTime.UtcNow
                });

                // Send notifications after database transaction is committed
                await _repository.CommitTransactionAsync();
                
                // Send notifications outside of the transaction to avoid DbContext conflicts
                await SendApprovalNotificationsAfterTransactionAsync(request, pharmacy, notificationData);
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }
        
        private async Task SendApprovalNotificationsAfterTransactionAsync(PharmacyRequest request, Pharmacy pharmacy, string notificationData)
        {
            try
            {
                // Notify the user about their pharmacy request approval
                await _notificationService.SendPharmacyRequestNotificationAsync(
                    request.UserId,
                    request.RequestId,
                    pharmacy.Name,
                    "Approved"
                );

                // Notify admins about the approval
                await _notificationService.SendNotificationToRolesAsync(
                    new[] { "Admin", "SuperAdmin" },
                    "Pharmacy Request Approved",
                    $"Pharmacy request for '{pharmacy.Name}' has been approved",
                    NotificationType.RequestUpdate,
                    notificationData
                );
            }
            catch (Exception ex)
            {
                // Log the error but don't fail the main operation
                Console.WriteLine($"Failed to send approval notifications: {ex.Message}");
            }
        }
        private async Task EnsureUserInRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);
            if (!userRoles.Contains(roleName, StringComparer.OrdinalIgnoreCase))
            {
                var result = await _userManager.AddToRoleAsync(user, roleName);
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"Failed to add user to {roleName} role.");
                }
            }
        }
        public async Task<(IEnumerable<PharmacyRequestDto> pharmacyRequests, MetaData metaData)> GetRequestsAsync(PharmacyRequestParameters pharmacyRequestParameters, bool trackChanges)
        {
            var requestsWithMetaData = await _repository.PharmacyRequestRepository.GetRequestsAsync(pharmacyRequestParameters, trackChanges);

            var pharmacyRequestsDto = _mapper.Map<IEnumerable<PharmacyRequestDto>>(requestsWithMetaData);

            return (pharmacyRequests: pharmacyRequestsDto, metaData: requestsWithMetaData.MetaData);
        }
        public async Task RejectRequestAsync(Guid requestId, bool trackChanges)
        {
            var request = await _repository.PharmacyRequestRepository.GetByIdAsync(requestId, trackChanges);

            if (request == null)
                throw new PharmacyRequestNotFoundException(requestId);

            request.Status = PharmacyRequestStatus.Rejected;

            // Use transaction to ensure data consistency
            await _repository.BeginTransactionAsync();
            try
            {
                await _repository.SaveAsync();
                
                // Prepare notification data
                var notificationData = JsonSerializer.Serialize(new { 
                    requestId = request.RequestId,
                    pharmacyName = request.Name,
                    userId = request.UserId,
                    status = "Rejected",
                    timestamp = DateTime.UtcNow
                });

                // Send notifications after database transaction is committed
                await _repository.CommitTransactionAsync();
                
                // Send notifications outside of the transaction to avoid DbContext conflicts
                await SendRejectionNotificationsAfterTransactionAsync(request, notificationData);
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }
        
        private async Task SendRejectionNotificationsAfterTransactionAsync(PharmacyRequest request, string notificationData)
        {
            try
            {
                // Notify the user about their pharmacy request rejection
                await _notificationService.SendPharmacyRequestNotificationAsync(
                    request.UserId,
                    request.RequestId,
                    request.Name,
                    "Rejected"
                );

                // Notify admins about the rejection
                await _notificationService.SendNotificationToRolesAsync(
                    new[] { "Admin", "SuperAdmin" },
                    "Pharmacy Request Rejected",
                    $"Pharmacy request for '{request.Name}' has been rejected",
                    NotificationType.RequestUpdate,
                    notificationData
                );
            }
            catch (Exception ex)
            {
                // Log the error but don't fail the main operation
                Console.WriteLine($"Failed to send rejection notifications: {ex.Message}");
            }
        }
    }
}
