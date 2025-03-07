using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record CreatePermissionDto
    {
        [Required(ErrorMessage = "Permission name is required.")]
        [MaxLength(50, ErrorMessage = "Permission name cannot exceed 50 characters.")]
        public required string Name { get; init; }
    }
}
