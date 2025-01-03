using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record MedicineForCreationDto
    {
        [Required(ErrorMessage = "Medicine name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; init; }

        [MaxLength(150, ErrorMessage = "Maximum length for the Description is 150 characters.")]
        public string Description { get; init; }

        [Required(ErrorMessage = "ActiveIngredient is a required field.")]
        public string ActiveIngredient { get; init; }

        [Required(ErrorMessage = "Dosage is a required field.")]
        public string Dosage { get; init;}

        [Required(ErrorMessage = "Brand is a required field.")]
        public string Brand { get; init; }

        [Required(ErrorMessage = "Logo is a required field.")]
        public string Logo { get; init; }
    }
}
