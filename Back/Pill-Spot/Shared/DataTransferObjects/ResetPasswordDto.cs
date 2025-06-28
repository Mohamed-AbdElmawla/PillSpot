using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record ResetPasswordDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; init; }

        [Required]
        public string Token { get; init; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string NewPassword { get; init; }
    }
}
