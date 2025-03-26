using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    public class PharmacyEmployeeService : IPharmacyEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public PharmacyEmployeeService(IRepositoryManager repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<PharmacyEmployeeDto> employees, MetaData metaData)> GetAllEmployeesAsync(EmployeesParameters employeesParameters, bool trackChanges)
        {
            var employees = await _repository.PharmacyEmployeeRepository.GetAllPharmacyEmployeesAsync(employeesParameters, trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<PharmacyEmployeeDto>>(employees);

            return (employeesDto, employees.MetaData);
        }

        public async Task<(IEnumerable<PharmacyEmployeeDto> employees, MetaData metaData)> GetEmployeesByPharmacyIdAsync(Guid pharmacyId, EmployeesParameters employeesParameters, bool trackChanges)
        {
            var employees = await _repository.PharmacyEmployeeRepository.GetEmployeesByPharmacyIdAsync(pharmacyId, employeesParameters, trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<PharmacyEmployeeDto>>(employees);

            return (employeesDto, employees.MetaData);
        }

        public async Task<(IEnumerable<PharmacyDto> pharmacies, MetaData metaData)> GetUserPharmaciesAsync(string userId, EmployeesParameters employeesParameters, bool trackChanges)
        {
            var pharmacies = await _repository.PharmacyEmployeeRepository.GetUserPharmaciesAsync(userId, employeesParameters, trackChanges);
            var pharmaciesDto = _mapper.Map<IEnumerable<PharmacyDto>>(pharmacies);

            return (pharmaciesDto, pharmacies.MetaData);
        }

        public async Task UpdateEmployeeAsync(Guid employeeId, PharmacyEmployeeForUpdateDto updateEmployeeDto, bool trackChanges)
        {
            var employeeEntity = await _repository.PharmacyEmployeeRepository.GetPharmacyEmployeeByIdAsync(employeeId, trackChanges);
            if (employeeEntity == null)
            {
                throw new Exception("Employee not found");
            }

            _mapper.Map(updateEmployeeDto, employeeEntity);
             _repository.PharmacyEmployeeRepository.UpdatePharmacyEmployee(employeeEntity);
            await _repository.SaveAsync();
        }

        public async Task<PharmacyEmployeeDto> AddPharmacyEmployeeAsync(PharmacyEmployeeForCreationDto employeeForCreationDto)
        {
            var employeeEntity = _mapper.Map<PharmacyEmployee>(employeeForCreationDto);
             _repository.PharmacyEmployeeRepository.AddPharmacyEmployee(employeeEntity);
            await _repository.SaveAsync();
            return _mapper.Map<PharmacyEmployeeDto>(employeeEntity);
        }

        public async Task DeleteEmployeeAsync(Guid employeeId, bool trackChanges)
        {
            var employeeEntity = await _repository.PharmacyEmployeeRepository.GetPharmacyEmployeeByIdAsync(employeeId, trackChanges);
            if (employeeEntity == null)
            {
                throw new Exception("Employee not found");
            }
            _repository.PharmacyEmployeeRepository.DeletePharmacyEmployee(employeeEntity);
            await _repository.SaveAsync();
        }



        public async Task<PharmacyEmployeeDto> GetEmployeeByIdAsync(Guid employeeId)
        {
            var employee = await _repository.PharmacyEmployeeRepository.GetEmployeeByIdAsync(employeeId, false);
            if (employee == null)
                throw new CategoryNotFoundException(employeeId);

            return _mapper.Map<PharmacyEmployeeDto>(employee);
        }
        public async Task<IEnumerable<PharmacyEmployeeDto>> GetEmployeesByPharmacyAsync(Guid pharmacyId)
        {
            var employees = await _repository.PharmacyEmployeeRepository.GetEmployeesByPharmacyAsync(pharmacyId, false);
            return _mapper.Map<IEnumerable<PharmacyEmployeeDto>>(employees);
        }

        public async Task<PharmacyEmployeeDto> GetEmployeeByEmailOrUsernameAsync(string emailOrUsername)
        {
            var employee = await _repository.PharmacyEmployeeRepository.GetEmployeeByEmailOrUsernameAsync(emailOrUsername, false);
            return _mapper.Map<PharmacyEmployeeDto>(employee);
        }

        public async Task DeleteEmployeeAsync(Guid employeeId)
        {
            var employee = await _repository.PharmacyEmployeeRepository.GetEmployeeByIdAsync(employeeId, true);
            if (employee == null)
                throw new CategoryNotFoundException(employeeId);
            _repository.PharmacyEmployeeRepository.DeletePharmacyEmployee(employee);
            await _repository.SaveAsync();
        }
    }
}
