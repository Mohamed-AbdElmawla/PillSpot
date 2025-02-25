using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CityForUpdateDto
    {
        [MaxLength(250, ErrorMessage = "City name cannot exceed 250 characters.")]
        public string? CityName { get; init; }

        public Guid? GovernmentId { get; init; }

    }
}
