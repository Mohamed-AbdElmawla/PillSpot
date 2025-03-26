using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IPharmacyEmployeeService
    {
        //Task<(IEnumerable<PharmacyEmployeeDto> employees, MetaData metaData)> GetAllEmployeesAsync(EmployeesParameters employeesParameters, bool trackChanges);
        //Task<(IEnumerable<PharmacyEmployeeDto> employees, MetaData metaData)> GetEmployeesByPharmacyIdAsync(Guid pharmacyId, EmployeesParameters employeesParameters, bool trackChanges);
        //Task<(IEnumerable<PharmacyDto> pharmacies, MetaData metaData)> GetPharmaciesByEmployeeIdAsync(Guid employeeId, EmployeesParameters employeesParameters, bool trackChanges);
        //Task UpdateEmployeeAsync(Guid employeeId, PharmacyEmployeeForUpdateDto updateEmployeeDto, bool trackChanges);
        //Task<PharmacyEmployeeDto> AddPharmacyEmployeeAsync(PharmacyEmployeeForCreationDto employeeForCreationDto);
        //Task DeleteEmployeeAsync(Guid employeeId, bool trackChanges);
        Task<(IEnumerable<PharmacyDto> pharmacies, MetaData metaData)> GetUserPharmaciesAsync(string userName, EmployeesParameters employeesParameters, bool trackChanges);
        Task<PharmacyEmployeeDto> GetEmployeeByIdAsync(Guid employeeId);
        Task<IEnumerable<PharmacyEmployeeDto>> GetEmployeesByPharmacyAsync(Guid pharmacyId);
        Task<PharmacyEmployeeDto> GetEmployeeByEmailOrUsernameAsync(string emailOrUsername);
        Task DeleteEmployeeAsync(Guid employeeId);

    }
}
