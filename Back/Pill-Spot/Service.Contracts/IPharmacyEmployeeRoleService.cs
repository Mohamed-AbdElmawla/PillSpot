namespace Service.Contracts
{
    public interface IPharmacyEmployeeRoleService
    {
        Task<bool> UserHasRoleInPharmacyAsync(string userId, string roleName, Guid pharmacyId,bool trackChanges);
    }

}
