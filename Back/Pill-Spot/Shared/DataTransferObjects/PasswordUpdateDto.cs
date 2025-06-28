using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record PasswordUpdateDto
    {
        [Required(ErrorMessage = "Old password is required.")]
        public string? OldPassword { get; init; }

        [Required(ErrorMessage = "New password is required.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long, contain one uppercase letter, one number, and one special character.")]
        public string? NewPassword { get; init; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; init; }
    }

}
