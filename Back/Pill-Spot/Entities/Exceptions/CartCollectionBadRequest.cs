using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CartCollectionBadRequest : BadRequestException
    {
        public CartCollectionBadRequest() : base("Cart collection sent from client is null.") { }
    }
}
