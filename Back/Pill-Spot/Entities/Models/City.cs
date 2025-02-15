using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class City
    {
        [Key]
        public short CityId { get; set; }

        [Required(ErrorMessage = "City name in Arabic is required.")]
        [MaxLength(250, ErrorMessage = "City name in Arabic cannot exceed 250 characters.")]
        public string CityNameAR { get; set; }

        [Required(ErrorMessage = "City name in English is required.")]
        [MaxLength(250, ErrorMessage = "City name in English cannot exceed 250 characters.")]
        public string CityNameEN { get; set; }

        [Required(ErrorMessage = "Government ID is required.")]
        public short GovernmentId { get; set; }

        [ForeignKey("GovernmentId")]
        public virtual Government Government { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}