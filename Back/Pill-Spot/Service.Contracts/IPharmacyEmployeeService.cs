using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IPharmacyEmployeeService
    {
        Task<(IEnumerable<PharmacyEmployeeProfileDto> pharmacies, MetaData metaData)> GetUserPharmaciesAsync(string userName, EmployeesParameters employeesParameters, bool trackChanges);
        //Task<PharmacyEmployeeDto> ManagerSendRequestToEmploee(PharmacyEmployeeForCreationDto employeeForCreationDto);
        //Task<(IEnumerable<PharmacyEmployeeDto> employees, Guid ids)> AddEmployeesCollectionAsync(IEnumerable<PharmacyEmployeeForCreationDto> employeesCollection);
        //Task<(IEnumerable<PharmacyEmployeeDto> employees, MetaData metaData)> GetAllEmployeesAsync(EmployeesParameters employeesParameters, bool trackChanges);
        //Task<PharmacyEmployeeDto> GetEmployeesByIdAsync(Guid id, bool trackChanges);
        //Task DeleteEmployeeAsync(Guid employeeId, bool trackChanges);
        //Task UpdateEmployeeAsync(Guid employeeId, PharmacyEmployeeForUpdateDto updateEmployeeDto, bool trackChanges);
    }
}
