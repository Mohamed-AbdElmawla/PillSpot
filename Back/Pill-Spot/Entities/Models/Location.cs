using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Private field for point calculation, not mapped to the database.
        private Point _geography;

        [NotMapped]
        public Point Geography
        {
            get
            {
                var geometryFactory = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                return geometryFactory.CreatePoint(new Coordinate(Longitude, Latitude));
            }
            private set
            {
                _geography = value;
            }
        }

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