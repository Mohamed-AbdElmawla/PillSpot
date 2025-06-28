using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CartNotFoundException : NotFoundException
    {
        public CartNotFoundException(Guid cartId)
            : base($"Cart with id: {cartId} doesn't exist in the database.") { }

        public CartNotFoundException(string userId)
            : base($"Cart for user with id: {userId} doesn't exist.") { }
    }
}
