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
            if (dto == null || dto.UserIds.All(string.IsNullOrWhiteSpace))
                throw new DtoArgumentNullException(nameof(dto));

            if (string.IsNullOrEmpty(currentUserId))
                throw new UsersIdArgumentNullException(currentUserId);

            var (currentUser, currentUserRoles) = await GetUserAndRolesAsync(currentUserId, isCurrentUser: true);

            var errorMessages = new List<string>();

            foreach (var userId in dto.UserIds)
            {
                if (string.IsNullOrWhiteSpace(userId))
                    continue;

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

        public async Task AssignUserRoleAsync(AssignUserRoleDto dto, string currentUserId)
        {
            if (dto == null)
                throw new System.ArgumentNullException(nameof(dto));

            if (string.IsNullOrEmpty(currentUserId))
                throw new ArgumentException("Current user id must be provided.", nameof(currentUserId));

            var (currentUser, currentUserRoles) = await GetUserAndRolesAsync(currentUserId, isCurrentUser: true);

            var (targetUser, targetUserRoles) = await GetUserAndRolesAsync(dto.UserId, isCurrentUser: false);

            if (!IsAllowedToManageUser(currentUserRoles, targetUserRoles))
                throw new UnauthorizedAccessException("You are not allowed to assign roles to this user.");

            var currentRoles = await _userManager.GetRolesAsync(targetUser);
            var removeResult = await _userManager.RemoveFromRolesAsync(targetUser, currentRoles);
            if (!removeResult.Succeeded)
                throw new Exception("Failed to remove user roles.");

            var addResult = await _userManager.AddToRoleAsync(targetUser, dto.Role);
            if (!addResult.Succeeded)
                throw new Exception("Failed to add user to role.");
            
            await _repositoryManager.SaveAsync();
        }

        private async Task ApplyUserAction(User user, string action)
        {
            switch (action)
            {
                case "Activate":
                    user.LockoutEnd = null;
                    break;
                case "Deactivate":
                    user.LockoutEnd = DateTimeOffset.MaxValue;
                    break;
                case "Delete":
                    user.IsDeleted = true;
                    break;
                default:
                    throw new ArgumentException("Invalid action specified.", nameof(action));
            }

            await _repositoryManager.SaveAsync();
        }

        private async Task<(User user, IList<string> roles)> GetUserAndRolesAsync(string userId, bool isCurrentUser)
        {
            var user = await _repositoryManager.AdminRepository.GetUserByIdAsync(userId,false);
            if (user == null)
            {
                if (isCurrentUser)
                    throw new UnauthorizedAccessException("Current user not found.");
                else
                    throw new ArgumentException("User not found.", nameof(userId));
            }

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
