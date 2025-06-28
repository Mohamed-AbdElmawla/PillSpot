// UserAddressService.cs
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class UserAddressService : IUserAddressService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public UserAddressService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<UserAddressDto> addresses, MetaData metaData)> GetAddressesForUserAsync(
            string userId, UserAddressRequestParameters parameters, bool trackChanges)
        {
            var addressesWithMetaData = await _repository.UserAddressRepository
                .GetAddressesForUserAsync(userId, parameters, trackChanges);

            var addressesDto = _mapper.Map<IEnumerable<UserAddressDto>>(addressesWithMetaData);

            return (addresses: addressesDto, metaData: addressesWithMetaData.MetaData);
        }

        public async Task<UserAddressDto> GetAddressAsync(string userId, Guid addressId, bool trackChanges)
        {
            await VerifyAddressOwnership(userId, addressId, trackChanges);

            var address = await _repository.UserAddressRepository.GetAddressAsync(addressId, trackChanges);

            if (address == null)
                throw new UserAddressNotFoundException(addressId);

            return _mapper.Map<UserAddressDto>(address);
        }

        public async Task<UserAddressDto> GetDefaultAddressAsync(string userId, bool trackChanges)
        {
            var address = await _repository.UserAddressRepository.GetDefaultAddressAsync(userId, trackChanges);

            if (address == null)
                throw new UserAddressNotFoundException(userId);

            return _mapper.Map<UserAddressDto>(address);
        }

        public async Task<UserAddressDto> CreateAddressAsync(string userId, UserAddressForCreationDto addressDto)
        {
            var addressEntity = _mapper.Map<UserAddress>(addressDto);

            // Check if this is the first address using repository method
            var hasExistingAddresses = await _repository.UserAddressRepository
                .UserHasAddressesAsync(userId);

            if (!hasExistingAddresses)
            {
                addressEntity.IsDefault = true;
            }

            _repository.UserAddressRepository.CreateAddress(userId, addressEntity);
            await _repository.SaveAsync();

            return _mapper.Map<UserAddressDto>(addressEntity);
        }

        public async Task UpdateAddressAsync(string userId, Guid addressId, UserAddressForUpdateDto addressDto, bool trackChanges)
        {
            await VerifyAddressOwnership(userId, addressId, trackChanges);

            var addressEntity = await _repository.UserAddressRepository.GetAddressAsync(addressId, trackChanges);
            _mapper.Map(addressDto, addressEntity);

            await _repository.SaveAsync();
        }

        public async Task DeleteAddressAsync(string userId, Guid addressId, bool trackChanges)
        {
            await VerifyAddressOwnership(userId, addressId, trackChanges);

            var address = await _repository.UserAddressRepository.GetAddressAsync(addressId, trackChanges);

            if (address.IsDefault)
            {
                await SetNewDefaultAfterDeletion(userId, addressId);
            }

            _repository.UserAddressRepository.DeleteAddress(address);
            await _repository.SaveAsync();
        }

        public async Task SetDefaultAddressAsync(string userId, Guid addressId, bool trackChanges)
        {
            await VerifyAddressOwnership(userId, addressId, trackChanges);

            // Reset all defaults for this user
            var currentDefault = await _repository.UserAddressRepository.GetDefaultAddressAsync(userId, trackChanges);
            if (currentDefault != null && currentDefault.AddressId != addressId)
            {
                currentDefault.IsDefault = false;
                _repository.UserAddressRepository.UpdateAddress(currentDefault);
            }

            // Set new default
            var newDefault = await _repository.UserAddressRepository.GetAddressAsync(addressId, trackChanges);
            newDefault.IsDefault = true;
            _repository.UserAddressRepository.UpdateAddress(newDefault);

            await _repository.SaveAsync();
        }

        private async Task VerifyAddressOwnership(string userId, Guid addressId, bool trackChanges)
        {
            var addressBelongsToUser = await _repository.UserAddressRepository
                .AddressBelongsToUserAsync(addressId, userId, trackChanges);

            if (!addressBelongsToUser)
                throw new UserAddressNotFoundException(addressId);
        }

        private async Task SetNewDefaultAfterDeletion(string userId, Guid addressIdToDelete)
        {
            var newDefaultCandidate = await _repository.UserAddressRepository
                .FindNextAvailableAddress(userId, addressIdToDelete);

            if (newDefaultCandidate != null)
            {
                newDefaultCandidate.IsDefault = true;
                _repository.UserAddressRepository.UpdateAddress(newDefaultCandidate);
            }
        }
    }
}