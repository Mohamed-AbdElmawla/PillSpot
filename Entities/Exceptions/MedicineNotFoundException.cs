using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class MedicineNotFoundException : NotFoundException
    {
        public MedicineNotFoundException(int medicineId) : base($"Medicine with id {medicineId} doesn't exist in the database.")
        {
            
        }
    }
}
