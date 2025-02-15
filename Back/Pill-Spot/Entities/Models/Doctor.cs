using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Doctor
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        public bool IsBusy { get; set; }

        [Required(ErrorMessage = "License ID is required.")]
        [MaxLength(450, ErrorMessage = "License ID cannot exceed 450 characters.")]
        public string LicenseID { get; set; }

        [Required(ErrorMessage = "Rate is required.")]
        [Range(0, 5, ErrorMessage = "Rate must be between 0 and 5.")]
        public decimal Rate { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}