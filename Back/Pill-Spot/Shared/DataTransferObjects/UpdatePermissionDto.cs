using System.ComponentModel.DataAnnotations;

public record UpdatePermissionDto
{
    [Required(ErrorMessage = "Permission name is required.")]
    [MaxLength(50, ErrorMessage = "Permission name cannot exceed 50 characters.")]
    public required string Name { get; init; }
}