using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record MedicineForCreationDto
    (
        string Name,
        string Description,
        string ActiveIngredient, 
        string Dosage,           
        string Brand,            
        string Logo,             
        string Manufacturer,     
        decimal Price            
    );
}
