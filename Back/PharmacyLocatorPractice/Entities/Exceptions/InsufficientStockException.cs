using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class InsufficientStockException : BadRequestException
    {
        public InsufficientStockException(string medicineId, int availableQuantity)
       : base($"Insufficient stock for medicine with MedicineId: {medicineId}. Available quantity: {availableQuantity}."){ }
    }
}
