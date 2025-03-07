using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record ForgotPasswordDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public required string Email { get; init; }
    }
}
