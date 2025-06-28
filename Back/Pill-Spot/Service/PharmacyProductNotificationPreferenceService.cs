using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using PillSpot.Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillSpot.Service;

public class PharmacyProductNotificationPreferenceService : IPharmacyProductNotificationPreferenceService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PharmacyProductNotificationPreferenceService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PharmacyProductNotificationPreferenceDto> GetUserProductPreferenceAsync(string userId, Guid productId, Guid? pharmacyId)
    {
        var preference = await _repository.PharmacyProductNotificationPreferenceRepository
            .GetUserProductPreferenceAsync(userId, productId, pharmacyId, false);

        if (preference == null)
            throw new PharmacyProductNotificationPreferenceNotFoundException(userId, productId, pharmacyId);

        var dto = _mapper.Map<PharmacyProductNotificationPreferenceDto>(preference);
        dto.PharmacyName = preference.Pharmacy?.Name;
        dto.ProductName = preference.Product?.Name;
        
        return dto;
    }

    public async Task<IEnumerable<PharmacyProductNotificationPreferenceDto>> GetUserPreferencesAsync(string userId)
    {
        var preferences = await _repository.PharmacyProductNotificationPreferenceRepository
            .GetUserPreferencesAsync(userId, false);

        var dtos = _mapper.Map<IEnumerable<PharmacyProductNotificationPreferenceDto>>(preferences);
        foreach (var dto in dtos)
        {
            var preference = preferences.FirstOrDefault(p => p.PreferenceId == dto.PreferenceId);
            if (preference != null)
            {
                dto.PharmacyName = preference.Pharmacy?.Name;
                dto.ProductName = preference.Product?.Name;
            }
        }

        return dtos;
    }

    public async Task<IEnumerable<PharmacyProductNotificationPreferenceDto>> GetUserProductPreferencesAsync(string userId, Guid productId)
    {
        var preferences = await _repository.PharmacyProductNotificationPreferenceRepository
            .GetUserProductPreferencesAsync(userId, productId, false);

        var dtos = _mapper.Map<IEnumerable<PharmacyProductNotificationPreferenceDto>>(preferences);
        foreach (var dto in dtos)
        {
            var preference = preferences.FirstOrDefault(p => p.PreferenceId == dto.PreferenceId);
            if (preference != null)
            {
                dto.PharmacyName = preference.Pharmacy?.Name;
                dto.ProductName = preference.Product?.Name;
            }
        }

        return dtos;
    }

    public async Task<PharmacyProductNotificationPreferenceDto> CreatePreferenceAsync(
        string userId,
        Guid productId,
        Guid? pharmacyId,
        PharmacyProductNotificationPreferenceForCreationDto preferenceDto)
    {
        var preference = _mapper.Map<PharmacyProductNotificationPreference>(preferenceDto);
        preference.UserId = userId;
        preference.ProductId = productId;
        preference.PharmacyId = pharmacyId;
        preference.CreatedAt = DateTime.UtcNow;

        _repository.PharmacyProductNotificationPreferenceRepository.CreatePreference(preference);
        await _repository.SaveAsync();

        var dto = _mapper.Map<PharmacyProductNotificationPreferenceDto>(preference);
        dto.PharmacyName = preference.Pharmacy?.Name;
        dto.ProductName = preference.Product?.Name;

        return dto;
    }

    public async Task UpdatePreferenceAsync(
        string userId,
        Guid productId,
        Guid? pharmacyId,
        PharmacyProductNotificationPreferenceForUpdateDto preferenceDto)
    {
        var preference = await _repository.PharmacyProductNotificationPreferenceRepository
            .GetUserProductPreferenceAsync(userId, productId, pharmacyId, true);

        if (preference == null)
            throw new PharmacyProductNotificationPreferenceNotFoundException(userId, productId, pharmacyId);

        _mapper.Map(preferenceDto, preference);
        await _repository.SaveAsync();
    }

    public async Task DeletePreferenceAsync(string userId, Guid productId, Guid? pharmacyId)
    {
        var preference = await _repository.PharmacyProductNotificationPreferenceRepository
            .GetUserProductPreferenceAsync(userId, productId, pharmacyId, true);

        if (preference == null)
            throw new PharmacyProductNotificationPreferenceNotFoundException(userId, productId, pharmacyId);

        _repository.PharmacyProductNotificationPreferenceRepository.DeletePreference(preference);
        await _repository.SaveAsync();
    }

    public async Task<bool> ShouldNotifyUserAsync(string userId, Guid productId, Guid? pharmacyId, string notificationType)
    {
        return await _repository.PharmacyProductNotificationPreferenceRepository
            .HasActivePreferenceAsync(userId, productId, pharmacyId, notificationType);
    }

    public async Task<IEnumerable<PharmacyProductNotificationPreferenceDto>> GetPreferencesForProductAndTypeAsync(Guid productId, string notificationType)
    {
        var preferences = await _repository.PharmacyProductNotificationPreferenceRepository
            .GetPreferencesForProductAndTypeAsync(productId, notificationType, false);

        var dtos = _mapper.Map<IEnumerable<PharmacyProductNotificationPreferenceDto>>(preferences);
        foreach (var dto in dtos)
        {
            var preference = preferences.FirstOrDefault(p => p.PreferenceId == dto.PreferenceId);
            if (preference != null)
            {
                dto.PharmacyName = preference.Pharmacy?.Name;
                dto.ProductName = preference.Product?.Name;
            }
        }

        return dtos;
    }
} 