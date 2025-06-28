using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using PillSpot.Contracts;
using PillSpot.Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillSpot.Service;

public class ProductNotificationPreferenceService : IProductNotificationPreferenceService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ProductNotificationPreferenceService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductNotificationPreferenceDto> GetUserProductPreferenceAsync(string userId, Guid productId)
    {
        var preference = await _repository.ProductNotificationPreferenceRepository
            .GetUserProductPreferenceAsync(userId, productId, false);

        if (preference == null)
            throw new ProductNotificationPreferenceNotFoundException(userId, productId.ToString());

        return _mapper.Map<ProductNotificationPreferenceDto>(preference);
    }

    public async Task<IEnumerable<ProductNotificationPreferenceDto>> GetUserPreferencesAsync(string userId)
    {
        var preferences = await _repository.ProductNotificationPreferenceRepository
            .GetUserPreferencesAsync(userId, false);

        return _mapper.Map<IEnumerable<ProductNotificationPreferenceDto>>(preferences);
    }

    public async Task<ProductNotificationPreferenceDto> CreatePreferenceAsync(
        string userId,
        Guid productId,
        ProductNotificationPreferenceForCreationDto preferenceDto)
    {
        var preference = _mapper.Map<ProductNotificationPreference>(preferenceDto);
        preference.UserId = userId;
        preference.ProductId = productId.ToString();

        _repository.ProductNotificationPreferenceRepository.CreatePreference(preference);
        await _repository.SaveAsync();

        return _mapper.Map<ProductNotificationPreferenceDto>(preference);
    }

    public async Task UpdatePreferenceAsync(
        string userId,
        Guid productId,
        ProductNotificationPreferenceForUpdateDto preferenceDto)
    {
        var preference = await _repository.ProductNotificationPreferenceRepository
            .GetUserProductPreferenceAsync(userId, productId, true);

        if (preference == null)
            throw new ProductNotificationPreferenceNotFoundException(userId, productId.ToString());

        _mapper.Map(preferenceDto, preference);
        await _repository.SaveAsync();
    }

    public async Task DeletePreferenceAsync(string userId, Guid productId)
    {
        var preference = await _repository.ProductNotificationPreferenceRepository
            .GetUserProductPreferenceAsync(userId, productId, true);

        if (preference == null)
            throw new ProductNotificationPreferenceNotFoundException(userId, productId.ToString());

        _repository.ProductNotificationPreferenceRepository.DeletePreference(preference);
        await _repository.SaveAsync();
    }

    public async Task<bool> ShouldNotifyUserAsync(string userId, Guid productId, string notificationType)
    {
        var preference = await _repository.ProductNotificationPreferenceRepository
            .GetUserProductPreferenceAsync(userId, productId, false);

        return preference != null && preference.IsEnabled && preference.NotificationTypes.Contains(notificationType);
    }
} 