using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UserAddressForCreationDto(
       [Required(ErrorMessage = "Label is required")]
        [MaxLength(50, ErrorMessage = "Label cannot be longer than 50 characters")]
        string Label,

       [Required(ErrorMessage = "Location is required")]
        LocationForCreationDto Location,

       bool IsDefault = false);
}
