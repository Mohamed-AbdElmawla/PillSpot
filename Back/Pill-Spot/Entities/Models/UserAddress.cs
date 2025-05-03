using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class UserAddress
    {
        [Key]
        public Guid AddressId { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public string Label { get; set; } // "Home", "Work", etc.

        [Required]
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }

        public bool IsDefault { get; set; }
    }
}
