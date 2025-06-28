using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Government
    {
        [Key]
        public Guid GovernmentId { get; set; }


        [Required(ErrorMessage = "Government name is required.")]
        [MaxLength(250, ErrorMessage = "Government name cannot exceed 250 characters.")]
        public required string GovernmentName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }
}