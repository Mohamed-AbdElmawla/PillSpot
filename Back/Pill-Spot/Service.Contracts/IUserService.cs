using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(string userName, bool trackChanges);
        Task<IEnumerable<UserDto>> GetUsersAsync(bool trackChanges);
        Task DeleteUserAsync(string userName, bool trackChanges);
        Task UpdateUserAsync(string userName, UserForUpdateDto userForUpdateDto, bool trackChanges);
        Task UpdatePasswordAsync(string userName, PasswordUpdateDto passwordDto);
        Task UpdateEmailAsync(string userName, EmailUpdateDto emailDto);
        Task ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
        Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
        Task AssignRoleAsync(string userName, string newRole);
        Task LockoutUserAsync(string userName, int days);
        Task UnlockUserAsync(string userName);
        Task<IEnumerable<string>> GetUserRolesAsync(string userName);
        Task SendEmailConfirmationAsync(string userName);
        Task ConfirmEmailAsync(string email, string token);
    }
}
