using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SearchHistory
    {
        [Key]
        public int SearchId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string SearchTerm { get; set; }

        [Required]
        [Range(-90, 90)]
        public decimal Latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public decimal Longitude { get; set; }

        [Required]
        public DateTime SearchDate { get; set; }

        // Navigation property
       //public User User { get; set; }
    }
}
