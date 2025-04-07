using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class OrderFoundException : NotFoundException
    {
        public OrderFoundException(Guid orderId):base($"Order with id: {orderId} was not found")
        {
            
        }
    }
}
