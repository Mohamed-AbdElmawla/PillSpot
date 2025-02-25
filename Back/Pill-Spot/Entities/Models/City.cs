using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class City
    {
        [Key]
        public Guid CityId { get; set; }

        [Required(ErrorMessage = "City name is required.")]
        [MaxLength(250, ErrorMessage = "City name cannot exceed 250 characters.")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Government ID is required.")]
        public Guid GovernmentId { get; set; }

        [ForeignKey("GovernmentId")]
        public virtual Government Government { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}