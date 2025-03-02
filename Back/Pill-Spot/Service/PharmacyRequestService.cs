using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace Service
{
    internal class PharmacyRequestService : IPharmacyRequestService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly ILocationService _locationService;
        private readonly UserManager<User> _userManager;
        public PharmacyRequestService(IRepositoryManager repository, IMapper mapper,
            UserManager<User> userManager, IFileService fileService, ILocationService locationService)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
            _locationService = locationService;
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
            await _repository.SaveAsync();
        }
        public async Task ApproveRequestAsync(ulong requestId, bool trackChanges)
        {
            var request = await _repository.PharmacyRequestRepository.GetByIdAsync(requestId, trackChanges);

            if (request == null)
                throw new PharmacyRequestNotFoundException(requestId);

            request.Status = PharmacyRequestStatus.Approved;

            var pharmacy = _mapper.Map<Pharmacy>(request);

            _repository.PharmacyRepository.CreatePharmacy(pharmacy);

            await _repository.SaveAsync();

        }

        public async Task<(IEnumerable<PharmacyRequestDto> pharmacyRequests, MetaData metaData)> GetPendingRequestsAsync(PharmacyRequestParameters pharmacyRequestParameters, bool trackChanges)
        {
            var requestsWithMetaData = await _repository.PharmacyRequestRepository.GetRequestsAsync(pharmacyRequestParameters, trackChanges);

            var pharmacyRequestsDto = _mapper.Map<IEnumerable<PharmacyRequestDto>>(requestsWithMetaData);

            return (pharmacyRequests: pharmacyRequestsDto, metaData: requestsWithMetaData.MetaData);
        }

        public async Task RejectRequestAsync(ulong requestId, bool trackChanges)
        {
            var request = await _repository.PharmacyRequestRepository.GetByIdAsync(requestId, trackChanges);

            if (request == null)
                throw new PharmacyRequestNotFoundException(requestId);

            request.Status = PharmacyRequestStatus.Rejected;

            await _repository.SaveAsync();
        }
    }
}
