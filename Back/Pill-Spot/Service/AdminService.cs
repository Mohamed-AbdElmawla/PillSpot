using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class AdminService : IAdminService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<User> _userManager;

        public AdminService(IRepositoryManager repositoryManager, UserManager<User> userManager)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
        }
        public async Task BulkManageUsersAsync(BulkUserManagementDto dto, string currentUserId ,bool trackChanges)
        {

            var (currentUser, currentUserRoles) = await GetUserAndRolesAsync(currentUserId, isCurrentUser: true,trackChanges);

            var errorMessages = new List<string>();

            foreach (var userId in dto.UserIds.Where(id => !string.IsNullOrWhiteSpace(id)))
            {
                var targetUser = await _repositoryManager.AdminRepository.GetUserByIdAsync(userId, trackChanges);
                if (targetUser == null)
                {
                    errorMessages.Add($"User with Id '{userId}' does not exist.");
                    continue;
                }

                var targetUserRoles = await _userManager.GetRolesAsync(targetUser);

                if (!IsAllowedToManageUser(currentUserRoles, targetUserRoles))
                {
                    string roles = string.Join(", ", targetUserRoles);
                    errorMessages.Add($"User with Id '{targetUser.UserName}' and Roles '{roles}' cannot be modified.");
                    continue;
                }

                await ApplyUserAction(targetUser, dto.Action);
            }

            if (errorMessages.Count > 0)
                throw new UnauthorizedAccessException(string.Join(Environment.NewLine, errorMessages));
        }
        public async Task AssignUserRoleAsync(AssignUserRoleDto dto, string currentUserId, bool trackChanges)
        {
            var (currentUser, currentUserRoles) = await GetUserAndRolesAsync(currentUserId, isCurrentUser: true,trackChanges);

            var (targetUser, targetUserRoles) = await GetUserAndRolesAsync(dto.UserId, isCurrentUser: false,trackChanges);

            if (!IsAllowedToManageUser(currentUserRoles, targetUserRoles))
                throw new NotAllowedToAssignRoleBadRequestException();

            if (targetUserRoles.Contains(dto.Role))
                throw new UserHaveRoleBadRequestException(dto.Role);

            var removeResult = await _userManager.RemoveFromRolesAsync(targetUser, targetUserRoles);
            if (!removeResult.Succeeded)
                throw new RemoveRoleBadRequestException();

            var addResult = await _userManager.AddToRoleAsync(targetUser, dto.Role);
            if (!addResult.Succeeded)
                throw new AddRoleBadRequestException();
            
            await _repositoryManager.SaveAsync();
        }
        private async Task ApplyUserAction(User user, string action)
        {
            switch (action)
            {
                case "Activate":
                    if (user.LockoutEnd == null)
                        throw new ActivateUserBadRequestException();
                    user.LockoutEnd = null;
                    break;
                case "Deactivate":
                    if (user.LockoutEnd != null && user.LockoutEnd.Value == DateTimeOffset.MaxValue)
                        throw new DeactivateUserBadRequestException();
                    user.LockoutEnd = DateTimeOffset.MaxValue;
                    break;
                case "Delete":
                    user.IsDeleted = true;
                    break;
                default:
                    throw new ActionBadRequestException(action);
            }           
            await _repositoryManager.SaveAsync();
            //Log.Information($"Changes saved successfully for user '{user.UserName}' , IsDeleted {user.IsDeleted}.");
        }
        private async Task<(User user, IList<string> roles)> GetUserAndRolesAsync(string userId, bool isCurrentUser, bool trackChanges)
        {
            var user = await _repositoryManager.AdminRepository.GetUserByIdAsync(userId,trackChanges);

            if (user == null)
                if (isCurrentUser)
                    throw new CurrentUserNotFoundException(userId);
                else
                    throw new UserNotFoundException(userId);

            var roles = await _userManager.GetRolesAsync(user);
            return (user, roles);
        }
        private bool IsAllowedToManageUser(IList<string> currentUserRoles, IList<string> targetUserRoles)
        {

            if (currentUserRoles.Contains("SuperAdmin"))
                return true;

            if (currentUserRoles.Contains("Admin"))
            {
                if (targetUserRoles.Contains("SuperAdmin") || targetUserRoles.Contains("Admin"))
                    return false;
                return true;
            }

            return false;
        }
    }
}
