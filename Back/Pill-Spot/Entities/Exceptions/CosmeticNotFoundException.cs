using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CosmeticNotFoundException: NotFoundException
    {
        public CosmeticNotFoundException(ulong productId) : base($"Cosmetics with id: {productId} wasn't found")
        {

        }
    }
}
