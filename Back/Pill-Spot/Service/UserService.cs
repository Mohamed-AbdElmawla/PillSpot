using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;
        public UserService(IRepositoryManager repository, IMapper mapper,
            UserManager<User> userManager, IFileService fileService = null, IEmailService emailService = null)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
            _emailService = emailService;
        }

        public async Task DeleteUserAsync(string userName, bool trackChanges)
        {
            var user = await _repository.UserRepository.GetUserAsync(userName, trackChanges);
            if (user == null)
                throw new UserNotFoundException(userName);

            user.IsDeleted = true;
            await _repository.SaveAsync();
        }

        public async Task<UserDto> GetUserAsync(string userName, bool trackChanges)
        {
            var user = await _repository.UserRepository.GetUserAsync(userName, trackChanges);

            if (user == null)
                throw new UserNotFoundException(userName);
            
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task UpdateUserAsync(string userName, UserForUpdateDto userForUpdateDto, bool trackChanges)
        {
            var user = await _repository.UserRepository.GetUserAsync(userName, trackChanges);

            if (user == null)
                throw new UserNotFoundException(userName);

            _mapper.Map(userForUpdateDto, user);
            if (_fileService != null && userForUpdateDto.ProfilePicture != null)
            {
                string imagePath = await _fileService.SaveFileAsync(userForUpdateDto.ProfilePicture, "Images");
                user.ProfilePictureUrl = imagePath;
            }

            await _repository.SaveAsync();
        }

        public async Task<(IEnumerable<UserDto> users, MetaData metaData)> GetUsersAsync(UserParameters userParameters, bool trackChanges)
        {
            var usersWithMetaData = await _repository.UserRepository.GetUsersAsync(userParameters, trackChanges);

            var usersDto = _mapper.Map<IEnumerable<UserDto>>(usersWithMetaData);

            return (users: usersDto, metaData: usersWithMetaData.MetaData);
        }


        public async Task UpdatePasswordAsync(string userName, PasswordUpdateDto passwordDto)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
                throw new UserNotFoundException(userName);

            var isOldPasswordValid = await _userManager.CheckPasswordAsync(user, passwordDto.OldPassword);

            if (!isOldPasswordValid)
                throw new InvalidPasswordException();

            var result = await _userManager.ChangePasswordAsync(user, passwordDto.OldPassword, passwordDto.NewPassword);

            if (!result.Succeeded)
                throw new PasswordChangeFailedException(string.Join(", ", result.Errors.Select(e => e.Description)));
        }


        public async Task UpdateEmailAsync(string userName, EmailUpdateDto emailDto)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                throw new UserNotFoundException(userName);

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, emailDto.Password);

            if (!isPasswordValid)
                throw new InvalidPasswordException();

            var token = await _userManager.GenerateChangeEmailTokenAsync(user, emailDto.NewEmail!);

            var result = await _userManager.ChangeEmailAsync(user, emailDto.NewEmail!, token);

            if (!result.Succeeded)
                throw new EmailUpdateFailedException(string.Join(", ", result.Errors.Select(e => e.Description)));      
        }
        // not working and don't forget PasswordResetTokenExpiry 
        public async Task ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
                throw new UserEmailNotFoundException(forgotPasswordDto.Email);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetUrl = $"https://your-frontend.com/reset-password?token={token}&email={user.Email}";
            var emailBody = $"Click <a href='{resetUrl}'>here</a> to reset your password.";

            await _emailService.SendEmailAsync(user.Email, "Reset Your Password", emailBody);
        }

        public async Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
                throw new UserEmailNotFoundException(resetPasswordDto.Email);

            var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.NewPassword);
            if (!result.Succeeded)
                throw new PasswordResetFailedException(string.Join(", ", result.Errors.Select(e => e.Description)));
        }


        public async Task AssignRoleAsync(string userName, string newRole)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                throw new UserNotFoundException(userName);

            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains(newRole))
            {
                await _userManager.RemoveFromRolesAsync(user, roles);
                await _userManager.AddToRoleAsync(user, newRole);
            }

        }

        public async Task LockoutUserAsync(string userName, int days = 30)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
                throw new UserNotFoundException(userName);

            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddDays(days));
            user.LockoutEnabled = true;
            await _userManager.UpdateAsync(user);
        }

        public async Task UnlockUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                throw new UserNotFoundException(userName);
            user.LockoutEnabled = false;
            await _userManager.SetLockoutEndDateAsync(user, null);
        }



        public async Task<IEnumerable<string>> GetUserRolesAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                throw new UserNotFoundException(userName);

            return await _userManager.GetRolesAsync(user);
        }
        public async Task SendEmailConfirmationAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                throw new UserNotFoundException(userName);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationUrl = $"https://your-frontend.com/confirm-email?token={token}&email={user.Email}";

            await _emailService.SendEmailAsync(user.Email, "Confirm Your Email", $"Click <a href='{confirmationUrl}'>here</a> to confirm your email.");
        }

        public async Task ConfirmEmailAsync(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new UserEmailNotFoundException(email);

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
                throw new EmailConfirmationFailedException(string.Join(", ", result.Errors.Select(e => e.Description)));
        }

    }
}

