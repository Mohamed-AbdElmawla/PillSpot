using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record RoleUpdateDto
    {
        [Required]
        public string? Role { get; init; }
    }
}
