using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Government
    {
        [Key]
        public short GovernmentId { get; set; }

        [Required(ErrorMessage = "Government name in Arabic is required.")]
        [MaxLength(250, ErrorMessage = "Government name in Arabic cannot exceed 250 characters.")]
        public string GovernmentNameAR { get; set; }

        [Required(ErrorMessage = "Government name in English is required.")]
        [MaxLength(250, ErrorMessage = "Government name in English cannot exceed 250 characters.")]
        public string GovernmentNameEN { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }
}