using Entities.Validators;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public class User : IdentityUser
    {
        [MaxLength(500, ErrorMessage = "Profile Picture URL cannot exceed 500 characters.")]
        public string? ProfilePictureUrl { get; set; }

        public Guid? LocationID { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        [BirthDateValidation(ErrorMessage = "You must be between 0 and 120 years old.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Created date is required.")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
        [RegularExpression(@"^[A-Za-z\s'-]+$", ErrorMessage = "First name can only contain letters, spaces, hyphens, and apostrophes.")]
        public string FirstName { get; set; }
      
        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
        [RegularExpression(@"^[A-Za-z\s'-]*$", ErrorMessage = "Last name can only contain letters, spaces, hyphens, and apostrophes.")]
        public string LastName { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

        [ForeignKey("LocationID")]
        public virtual Location? Location { get; set; }

        public virtual ICollection<AdminPermission> AdminPermissions { get; set; } = new List<AdminPermission>();
        public virtual ICollection<SearchHistory> SearchHistories { get; set; } = new List<SearchHistory>();
        public virtual ICollection<PharmacyRequest> PharmacyRequests { get; set; } = new List<PharmacyRequest>();
        [InverseProperty("AdminUser")]
        public virtual ICollection<PharmacyRequest> ReviewedPharmacyRequests { get; set; } = new List<PharmacyRequest>();
        public bool IsDeleted { get; set; } = false;

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}