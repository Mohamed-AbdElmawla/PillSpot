using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CityForCreationDto
    {
        [Required(ErrorMessage = "City name is required.")]
        [MaxLength(250, ErrorMessage = "City name in English cannot exceed 250 characters.")]
        public string CityName { get; init; }

        [Required(ErrorMessage = "Government ID is required.")]
        public Guid GovernmentId { get; init; }
    }
}
