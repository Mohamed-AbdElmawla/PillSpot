using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    internal sealed class PrescriptionService : IPrescriptionService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public PrescriptionService(IRepositoryManager repository, IMapper mapper, IFileService fileService)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<(IEnumerable<PrescriptionDto> prescriptions, MetaData metaData)> GetAllPrescriptionsAsync(PrescriptionParameters prescriptionParameters, bool trackChanges)
        {
            var prescriptionsWithMetaData = await _repository.PrescriptionRepository.GetAllPrescriptionAsync(prescriptionParameters, trackChanges);
            var prescriptionsDto = _mapper.Map<IEnumerable<PrescriptionDto>>(prescriptionsWithMetaData);
            return (prescriptions: prescriptionsDto, metaData: prescriptionsWithMetaData.MetaData);
        }

        public async Task<PagedList<PrescriptionDto>> GetPrescriptionsByUserAsync(string userId, PrescriptionParameters prescriptionParameters, bool trackChanges)
        {
            var prescriptions = await _repository.PrescriptionRepository.GetPrescriptionUserAsync(userId, trackChanges);
            var prescriptionsDto = _mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
            return PagedList<PrescriptionDto>.ToPagedList(prescriptionsDto, prescriptionParameters.PageNumber, prescriptionParameters.PageSize);
        }

        public async Task<PrescriptionDto> GetPrescriptionByIdAsync(Guid id, bool trackChanges)
        {
            var prescription = await GetPrescriptionByIdAndCheckIfExists(id, trackChanges);
            return _mapper.Map<PrescriptionDto>(prescription);
        }

        public async Task<PrescriptionDto> CreatePrescriptionAsync(PrescriptionForCreationDto prescriptionDto)
        {
            var prescriptionEntity = _mapper.Map<Prescription>(prescriptionDto);

            if (prescriptionDto.ImageFile != null)
                prescriptionEntity.ImageUrl = await _fileService.AddProductImageIfNotNull(prescriptionDto.ImageFile);

            _repository.PrescriptionRepository.CreatePrescription(prescriptionEntity);

            await _repository.SaveAsync();

            return _mapper.Map<PrescriptionDto>(prescriptionEntity);
        }

        public async Task UpdatePrescriptionAsync(Guid id, PrescriptionForUpdateDto prescriptionDto, bool trackChanges)
        {
            var prescriptionEntity = await GetPrescriptionByIdAndCheckIfExists(id, trackChanges);

            // Update Prescription
            _mapper.Map(prescriptionDto, prescriptionEntity);

            // Handle PrescriptionProducts (Replace existing products)
            var existingProducts = await _repository.PrescriptionProductRepository.GetPrescriptionProductsByPrescriptionIdAsync(id, trackChanges);
            _repository.PrescriptionProductRepository.DeletePrescriptionProductsRange(existingProducts);

            var newProducts = _mapper.Map<IEnumerable<PrescriptionProduct>>(prescriptionDto.PrescriptionProducts);
            foreach (var product in newProducts)
            {
                var productEntity = await _repository.ProductRepository.GetProductAsync(product.ProductId, false);
                if (productEntity == null)
                    throw new ProductNotFoundException(product.ProductId);
                product.PrescriptionId = id;
            }
            _repository.PrescriptionProductRepository.AddPrescriptionProductsRange(newProducts);

            if (prescriptionDto.ImageFile != null)
                prescriptionEntity.ImageUrl = await _fileService.AddProductImageIfNotNull(prescriptionDto.ImageFile);

            await _repository.SaveAsync();
        }

        public async Task DeletePrescriptionAsync(Guid id, bool trackChanges)
        {
            var prescriptionEntity = await GetPrescriptionByIdAndCheckIfExists(id, trackChanges);
            _repository.PrescriptionRepository.DeletePrescription(prescriptionEntity);
            await _repository.SaveAsync();
        }

        private async Task<Prescription> GetPrescriptionByIdAndCheckIfExists(Guid id, bool trackChanges)
        {
            var prescription = await _repository.PrescriptionRepository.GetPrescriptionByIdAsync(id, trackChanges);
            if (prescription == null)
                throw new PrescriptionNotFoundException(id);
            return prescription;
        }
    }
}