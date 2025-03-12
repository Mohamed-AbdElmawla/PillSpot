using Entities.Validators;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace Shared.DataTransferObjects
{
    public record UserForUpdateDto
    {
        [MaxLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
        [RegularExpression(@"^[A-Za-z\s'-]+$", ErrorMessage = "First name can only contain letters, spaces, hyphens, and apostrophes.")]
        public string? FirstName { get; init; }

        [MaxLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
        [RegularExpression(@"^[A-Za-z\s'-]*$", ErrorMessage = "Last name can only contain letters, spaces, hyphens, and apostrophes.")]
        public string? LastName { get; init; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? PhoneNumber { get; init; }

        [AllowedFileExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        [MaxFileSize(1 * 1024 * 1024)]
        public IFormFile? ProfilePicture { get; set; }

        [DataType(DataType.Date)]
        [BirthDateValidation(ErrorMessage = "You must be between 0 and 120 years old.")]
        public DateTime? DateOfBirth { get; set; }

        [EnumDataType(typeof(Gender), ErrorMessage = "Gender must be 'Male' or 'Female'.")]
        public Gender? Gender { get; set; }

    }

}
