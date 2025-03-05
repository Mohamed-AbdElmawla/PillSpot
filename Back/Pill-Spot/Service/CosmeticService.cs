using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class CosmeticService : ICosmeticService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CosmeticService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CosmeticDto> CreateCosmeticAsync(CosmeticForCreationDto cosmetic)
        {
            var cosmeticEntity = _mapper.Map<Cosmetic>(cosmetic);
            _repository.CosmeticRepository.CreateCosmetic(cosmeticEntity);
            await _repository.SaveAsync();
            return _mapper.Map<CosmeticDto>(cosmeticEntity);
        }

        public async Task DeleteCosmetic(ulong productId, bool trackChanges)
        {
            var cosmetic = await _repository.CosmeticRepository.GetCosmeticAsync(productId, trackChanges);
            if (cosmetic == null)
                throw new CosmeticNotFoundException(productId);

            _repository.CosmeticRepository.DeleteCosmetic(cosmetic);
            await _repository.SaveAsync();
        }

        public async Task<CosmeticDto> GetCosmeticAsync(ulong productId, bool trackChanges)
        {
            var cosmetic = await _repository.CosmeticRepository.GetCosmeticAsync(productId, trackChanges);
            if (cosmetic == null)
                throw new CosmeticNotFoundException(productId);

            return _mapper.Map<CosmeticDto>(cosmetic);
        }
    }
}
