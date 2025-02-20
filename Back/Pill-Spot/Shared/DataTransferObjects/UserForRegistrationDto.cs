using Entities.Validators;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public enum Gender
    {
        Male,
        Female
    }

    public record UserForRegistrationDto
    {
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
        [RegularExpression(@"^[A-Za-z\s'-]+$", ErrorMessage = "First name can only contain letters, spaces, hyphens, and apostrophes.")]
        public string? FirstName { get; init; }

        [MaxLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
        [RegularExpression(@"^[A-Za-z\s'-]*$", ErrorMessage = "Last name can only contain letters, spaces, hyphens, and apostrophes.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long, contain one uppercase letter, one number, and one special character.")]
        public string? Password { get; init; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? PhoneNumber { get; init; }

        [Required(ErrorMessage = "Profile picture is required.")]
        [AllowedFileExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        [MaxFileSize(1 * 1024 * 1024)]
        public IFormFile? ProfilePicture { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        [BirthDateValidation(ErrorMessage = "You must be between 0 and 120 years old.")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public Gender? Gender { get; set; }

    }
}
