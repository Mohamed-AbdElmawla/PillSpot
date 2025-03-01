using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class SubCategoryNotFoundException : NotFoundException
    {
        public SubCategoryNotFoundException(int subCategoryId):base($"Sub category with id: {subCategoryId} wasn't found")
        {
            
        }
    }
}
