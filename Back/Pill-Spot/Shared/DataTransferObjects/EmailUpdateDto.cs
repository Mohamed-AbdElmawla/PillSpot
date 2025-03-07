using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record EmailUpdateDto
    {
        [Required(ErrorMessage = "New email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? NewEmail { get; init; }

        [Required(ErrorMessage = "Password is required for email update.")]
        public string? Password { get; init; }
    }

}
