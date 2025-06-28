using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Entities.Models
{
    public class Location
    {
        [Key]
        public Guid LocationId { get; set; }

        [Required]
        [Range(-180, 180)]
        public double Longitude { get; set; }

        [Required]
        [Range(-90, 90)]
        public double Latitude { get; set; }

        [NotMapped]
        public Point Geography => new Point(Longitude, Latitude) { SRID = 4326 };  // Use NotMapped to ignore this in DB

        [Required]
        [MaxLength(250)]
        public string AdditionalInfo { get; set; }

        [Required]
        public Guid CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}