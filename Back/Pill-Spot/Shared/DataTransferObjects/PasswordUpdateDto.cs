using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record PasswordUpdateDto
    {
        [Required(ErrorMessage = "Old password is required.")]
        public string? OldPassword { get; init; }

        [Required(ErrorMessage = "New password is required.")]

        public string? NewPassword { get; init; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; init; }
    }

}
