using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record GovernmentForUpdateDto
    {
        [Required(ErrorMessage = "Government name is required.")]
        [MaxLength(250, ErrorMessage = "Government name cannot exceed 250 characters.")]
        public string GovernmentName { get; init; }

        public bool IsDeleted { get; init; }
    }
}
